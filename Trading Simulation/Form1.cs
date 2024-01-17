using System.Threading;
using System.Windows.Forms;
using System;

using System.Data;
using System.Diagnostics;

using System.Windows.Forms.DataVisualization.Charting;
using ScottPlot.WinForms;





namespace Trading_Simulation
{
    public partial class Form1 : Form
    {
        #region SECTION : DEFINE VARIABLES
        private bool mFlag_IStradingStarted= false;
        private bool mFlag_IsUserID_Validated = false;



        private DataTable Dt_trades_Execution;
        Random SumulateTick;

        public static System.Windows.Forms.Timer Timer_feed;
        public static System.Windows.Forms.Timer Timer_trades;

        public double[] liveQuote;
        #endregion

        #region SECTION : INIT Variables + Method in  CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
            if( ! ConfigureUser() )
            {
                //Returna and Close
            }
            AddLog("Starting Application");

            this.Dt_trades_Execution = new DataTable();
            SumulateTick = new Random();
            liveQuote = new double[1];
            AddLog("Initializing Setup");


            if (mFlag_IsUserID_Validated)
            {
                // initialise all Functions here..
                Design_Trades_execution();
                AddLog("Loading Trades Execution Trading Environment");
                Set_timer();
                AddLog("Feed Started");
                //StartPlotiing();

                StartPlotiing();
            }
            else
            {
                AddLog("Failed to Start -Feed");
                AddLog("Failed to Load Trades Execution ");
            }
        }
        #endregion

        #region SECTION : Function will be responsible to dispaly event in log box (GUI)
        private void AddLog(string Message)
        {
            listBox1_log.Items.Add(DateTime.Now.ToString() + "  " + Message);
        }
        #endregion

        #region SECTION : AUTHENTICATE USER (If userid registered , Authenticate and Allow to use Trading Platform)

        #region SECTION : Configure USER CREDENTIAl
        private bool ConfigureUser()
        {
            bool isAuthorized = false;

            try
            {
                var b = new FormAuthenticate(); 
                b.eventsubmit +=   new EventHandler(Login__SubmitButton);
                b.eventclose += new EventHandler(Login_CLOSE);
                b.ShowDialog();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get LTP - Tick : {ex.Message}");
            }
            return isAuthorized;
        }
        #endregion

        #region SECTION : EVENT CODE TO HANDLE SUBMIT BUTTON
        private void Login__SubmitButton(object sender, EventArgs e)
        {
            var Y = (bool)sender;
            try
            {
                if(Y == true)
                {
                    AddLog("User is Validated");
                    mFlag_IsUserID_Validated = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Event Failed - SUBMIT Button : {ex.Message}");
            }
        }
        #endregion

        #region SECTION : EVENT CODE TO HANDLE CLOSE/EXIT BUTTON
        private void Login_CLOSE(object sender, EventArgs e)
        {
            var Y = (string)sender;
            try
            {
                if(Y.Equals("Cancel"))
                {
                    //TODO : FORCEFULLY CLOSE AND EXIT
                    System.Environment.Exit(0); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Event Failed - CLOSE/EXIT Button : {ex.Message}");
            }
        }
        #endregion

        #endregion

        private void StartPlotiing()
        {

            try
            {
                formsPlot1 = new() { Dock = DockStyle.Fill };
                this.Controls.Add(formsPlot1);

                // Add sample data to the plot
                double[] data = ScottPlot.Generate.Sin();
                formsPlot1.Plot.Add.Signal(data);
                formsPlot1.Refresh();

                panel2_chart.Controls.Add(formsPlot1);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get LTP - Tick : {ex.Message}");
            }

        }

        private Chart CreateChart()
        {
            // Create a new chart
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Create a new series for the chart
            Series series = new Series("Sample Series");
            series.ChartType = SeriesChartType.Line;

            // Add data points to the series
            series.Points.AddXY("Category 1", 10);
            series.Points.AddXY("Category 2", 20);
            series.Points.AddXY("Category 3", 15);
            series.Points.AddXY("Category 4", 25);

            // Add the series to the chart
            chart.Series.Add(series);

            // Customize chart appearance if needed
            //chart.ChartAreas[0].AxisX.Title = "Categories";
            //chart.ChartAreas[0].AxisY.Title = "Values";

            return chart;
        }

        #region SECTION : TIMER-? SET ALL PARAMETER TO ACTIVATE TIMER (SET EXECUTION PATH FOR SUB FUNCTION)
        private void Set_timer()
        {
            Timer_feed = new System.Windows.Forms.Timer();
            Timer_feed.Interval = 1000;
            Timer_feed.Tick += new System.EventHandler(this.Event_update_tick); //Method attached


            Timer_trades = new System.Windows.Forms.Timer();
            Timer_trades.Interval = 2000;
            Timer_trades.Tick += new System.EventHandler(this.Event_update_opentrades); //Method attached
        }
        #endregion

        #region SECTION : DESIGN STRUCTURE FOR TRADES EXECUTION & Bind To DataGrid View To Display
        private void Design_Trades_execution()
        {
            // Add Trading Columns  In Data Table
            Dt_trades_Execution.Columns.Add("Symbol", typeof(string));
            Dt_trades_Execution.Columns.Add("Quantity", typeof(int));
            Dt_trades_Execution.Columns.Add("Price", typeof(double));
            Dt_trades_Execution.Columns.Add("OrderType", typeof(string));
            Dt_trades_Execution.Columns.Add("EntryTime", typeof(DateTime));
            Dt_trades_Execution.Columns.Add("Status", typeof(string));
            Dt_trades_Execution.Columns.Add("Ltp", typeof(double));
            Dt_trades_Execution.Columns.Add("PnL", typeof(double));
            Dt_trades_Execution.Columns.Add("ExitPrice", typeof(double));
            Dt_trades_Execution.Columns.Add("ExitTime", typeof(string));

            // bind with view
            dgv_trades.DataSource = Dt_trades_Execution;
        }
        #endregion

        #region SECTION : TIMER FUNC()  - SIMULATE STOCKS PRICE  - USING  Random Price Class
        /// <summary>
        /// get_live_tick() will simulate Live Tick price .  you can Chnage it with API , Or Web Socked Endpoints 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_update_tick (object sender, EventArgs e)
        {
            get_live_tick();
        }
        #endregion

        #region SECTION : TIMER FUNC() - THIS  Function will be Responsible to updated LTP and Also calculate PNL of Open Trades
        /// <summary>
        /// update_trades_pnl()  - This Function will handled All Pnl and Exit Calculation of open Trades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_update_opentrades(object sender, EventArgs e)
        {
            update_trades_pnl();
        }
        #endregion

        #region SECTION:  This func() will act as Live Feed or Market Feed , Where  I have used Array to Store Price
        /// <summary>
        /// THis is the code are ,  if Socket is Active  Configure it and use, And You can Also use API to get Connected and Get market Feed
        /// </summary>
        private void get_live_tick()
        {
            try
            {
                liveQuote[0] = Math.Round(SumulateTick.NextDouble() * (21670 - 21650) + 21650, 2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get LTP - Tick : {ex.Message}");
            }
        }
        #endregion

        #region SECTION: Func() responsible to Update LTP (tick) in Gui Above Trades Execution (in text Box)
        private void update_LTP_in_gui()
        {
            try
            {
                double price = liveQuote[0];
                if(price != 0.0)
                {
                    this.textBox1_ltp.Text = price.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to update lrp in View : {ex.Message}");
            }
        }
        #endregion

        #region SECTION :Func() will calculaet PNL 
        /// <summary>
        /// Func()  Calculate PNL
        /// </summary>
        /// <param name="EntryPrice"></param>
        /// <param name="ltp"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        private double calculate_pnl(double EntryPrice, double ltp , int Quantity)
        {
           double  res = 0.0;
            try
            {
                if (ltp != 0)
                {
                    res = Math.Round((ltp - EntryPrice) * Quantity, 2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to update ltp of open Trades: {ex.Message}");
            }
            return res;
        }
        #endregion

        #region SECTION :Func() will Update PNL in Back End  for OPEN Trades (Status equals to open)
        private void update_trades_pnl()
        {
            foreach (DataRow row in this.Dt_trades_Execution.Rows)
            {
                if (row["Status"].ToString() == Status.mOpen)
                {
                    //Get LTP
                    double entryprice = Convert.ToDouble(row["Price"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    double ltp = liveQuote[0];


                    if(ltp==0.0)
                    {
                        continue;
                    }

                    string orderType  = row["OrderType"].ToString();

                    double pnl = 0.0;
                    if(orderType == OrderType.mBUY)
                    {
                        pnl= calculate_pnl(entryprice, ltp, quantity);
                    }
                    else //(orderType == OrderType.mSELL)
                    {
                        pnl = calculate_pnl(ltp, entryprice, quantity);
                    }
                    row["Ltp"] = ltp;
                    row["PnL"] = pnl;
                }
            }

            this.update_LTP_in_gui();
            this.Change_Pnl_color();
        }
        #endregion

        #region SECTION :Func() will Change Pnl Color in View  (GUI)
        private void Change_Pnl_color()
        {
            try
            {
                foreach(DataGridViewRow trade in this.dgv_trades.Rows)
                {
                    double pnl = Convert.ToDouble(trade.Cells["Pnl"].Value);

                    if(pnl >  0.0)
                    {
                        trade.Cells["Pnl"].Style.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        trade.Cells["Pnl"].Style.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Load Delegate : {ex.Message}");
            }
        }
        #endregion

        #region SECTION : Func() Will responsible to Generate New Trades when use Click THe Controls . This Code has tendency to Bifurcate Buy/Suy signals
        private void Generate_new_trades(ref DataTable dt , string ordertype)
        {
            try
            {
                // Create a new DataRow
                DataRow newRow = dt.NewRow();
                string symbol = "NIFTY 50";
                Int64 quantity = 1;

                double price = liveQuote[0];

                // Set values for each column
                newRow["Symbol"] = symbol;
                newRow["Quantity"] = quantity;
                newRow["Price"] = price;
                newRow["OrderType"] = ordertype;
                newRow["EntryTime"] = DateTime.Now;
                newRow["Status"] = Status.mOpen;
                newRow["Ltp"] = price;
                newRow["PnL"] = 0.0;
                newRow["ExitPrice"] = -1;
                newRow["ExitTime"] = -1;

                // Add the DataRow to the DataTable
                dt.Rows.Add(newRow);
                AddLog($"NEW Trades Entry tsym:{symbol} , price : {price} , OrderType : {ordertype }, Qty : {quantity}  ");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Load Delegate : {ex.Message}");
                AddLog($"Error While Taking New Trades , Please Close ");
            }
        }
        #endregion

        #region SECTION : EVENT - Call Func() When Trading Button is Clicked
        private void button1_starttradong_Click(object sender, EventArgs e)
        {
            if(mFlag_IsUserID_Validated== false)
            {
                MessageBox.Show("User Credential Not Registered.. Please close and Restart Again");
                return;
            }

            if (mFlag_IStradingStarted == false)
            {
                AddLog("User Clicked Start Trading");

                //Start Trading mFlag_tradingStarted = True
                mFlag_IStradingStarted = true;

                Timer_feed.Start();
                AddLog("Feed Started");
                Timer_trades.Start();
                AddLog("Ready to Take New Trades");
            }
        }
        #endregion

        #region SECTION : EVENT - Call Func() When BUY Button is Clicked

        private void button2_buy_Click(object sender, EventArgs e)
        {
            if (mFlag_IsUserID_Validated == false)
            {
                MessageBox.Show("User Credential Not Registered");
                return;
            }

            if (mFlag_IStradingStarted== true)
            {
                Generate_new_trades(ref this.Dt_trades_Execution, OrderType.mBUY);
            }
            else
            {
                MessageBox.Show("Please Start Trading... Than Proceed");
            }
        }
        #endregion

        #region SECTION : EVENT - Call Func() When SELL Button is Clicked
        private void button3_sell_Click(object sender, EventArgs e)
        {
            if (mFlag_IsUserID_Validated == false)
            {
                MessageBox.Show("User Credential Not Registered");
                return;
            }
            if (mFlag_IStradingStarted == true)
            {
                Generate_new_trades(ref this.Dt_trades_Execution, OrderType.mSELL);
            }
            else
            {
                MessageBox.Show("Please Start Trading... Than Proceed");
            }
        }
        #endregion
    }



    #region SECTION: This Class variable will be used In Status Field (CLASS WITH CONST VARIBALE) 
    public class Status
    {
        public const string  mOpen  = "Open";
        public const string mClose  = "Close";

    }
    #endregion

    #region SECTION: This Class variable will be used to classify Fields variable (CLASS WITH CONST VARIBALE) 
    public class OrderType
    {
        public const string mBUY = "B";
        public const string mSELL = "S";
    }
    #endregion


}