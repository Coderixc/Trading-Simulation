using System.Threading;
using System.Windows.Forms;
using System;

using System.Data;
using System.Diagnostics;

using System.Windows.Forms.DataVisualization.Charting;





namespace Trading_Simulation
{
    public partial class Form1 : Form
    {
        #region  : SECTION DEFINE VARIABLES

        private bool mFlag_IStradingStarted= false;
        private bool mFlag_IsUserID_Validated = false;
        private Chart chart;


        private DataTable Dt_trades_Execution;
        Random random;


        public static System.Windows.Forms.Timer Timer_feed;
        public static System.Windows.Forms.Timer Timer_trades;

        public double[] liveQuote; 

        #endregion

        public Form1()
        {
            InitializeComponent();
            if( ! ConfigureUser() )
            {


                //Returna and Close
            }
            AddLog("Starting Application");



            this.Dt_trades_Execution = new DataTable();
            random = new Random();
            liveQuote = new double[1];
            AddLog("Initializing Setup");



            // initialise all Functions here..
            Design_Trades_execution();
            AddLog("Loading Trades Execution Trading Environment");
            Set_timer();
            AddLog("Feed Started");
            //StartPlotiing();
        }

        private void AddLog(string Message)
        {
            listBox1_log.Items.Add(DateTime.Now.ToString() + "  " + Message);

        }

        #region SECTION : AUTHENTICATE USER

        private bool  ConfigureUser()
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

            }


        }

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

            }

        }



        #endregion



        private void StartPlotiing()
        {

            try
            {
                //Add the FormsPlot
                //Chart chart = new Chart();
                //chart.Dock = DockStyle.Fill;
                Chart chart = CreateChart();


                panel2_chart.Controls.Add(chart);

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

        private void Set_timer()
        {
            Timer_feed = new System.Windows.Forms.Timer();
            Timer_feed.Interval = 1000;
            Timer_feed.Tick += new System.EventHandler(this.Event_update_tick); //Method attached


            Timer_trades = new System.Windows.Forms.Timer();
            Timer_trades.Interval = 2000;
            Timer_trades.Tick += new System.EventHandler(this.Event_update_opentrades); //Method attached
        }


        private void Design_Trades_execution()
        {
            // add Trading Columns  In Data Table

            // Add columns to the DataTable
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

        private void Event_update_tick (object sender, EventArgs e)
        {
            get_live_tick();
        }

        private void Event_update_opentrades(object sender, EventArgs e)
        {
            update_trades_pnl();
        }



        private double get_live_tick()
        {
            double ltp = 0.0;
            try
            {

                ltp = Math.Round(random.NextDouble() * (21670 - 21650) + 21650, 2);

                liveQuote[0] = ltp;

                //Console.WriteLine("Ltp is  ", ltp);

                //update_LTP_in_gui();

                //this.Invoke((MethodInvoker)delegate
                //{
                //    update_LTP_in_gui();
                //});
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get LTP - Tick : {ex.Message}");
            }

            return ltp;

        }

        private void update_LTP_in_gui()
        {
            try
            {
                double price = get_live_tick();

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
                    string orderType  =  row["OrderType"].ToString();


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
                    // Optionally, you can update other fields as needed
                    // row["ExitTime"] = DateTime.Now;
                    // row["Status"] = "Closed";
                    ; // Exit the loop once the row is updated
                }
            }

            update_LTP_in_gui();
            Change_Pnl_color();
        }

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



        private void Generate_new_trades(ref DataTable dt , string ordertype)
        {

            try
            {

                // Create a new DataRow
                DataRow newRow = dt.NewRow();


                string symbol = "NIFTY 50";
                Int64 quantity = 1;

                //Random Number as a Stocks Entry Price
                Random random = new Random();

                // Generating a random number between 21650 and 21670 (inclusive)
                double price = Math.Round( random.NextDouble() * (21670 - 21650) + 21650 , 2);


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
            }
        }

        private void button1_starttradong_Click(object sender, EventArgs e)
        {
            if(mFlag_IsUserID_Validated== false)
            {
                MessageBox.Show("User Credential Not Registered");
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
    }




    public class Status
    {
        public const string  mOpen  = "Open";
        public const string mClose  = "Close";

    }

    public class OrderType
    {
        public const string mBUY = "B";
        public const string mSELL = "S";
    }

    
}