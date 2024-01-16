using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Trading_Simulation
{
    public partial class Form1 : Form
    {
        #region  : SECTION DEFINE VARIABLES

        private bool mFlag_IStradingStarted= false;


        private DataTable Dt_trades_Execution;
        Random random;


        public static System.Windows.Forms.Timer Timer_feed;

        #endregion

        public Form1()
        {
            InitializeComponent();

            this.Dt_trades_Execution = new DataTable();
            random = new Random();



            // initialise all Functions here..
            Design_Trades_execution();
            Set_timer();
        }

        private void Set_timer()
        {
            Timer_feed = new System.Windows.Forms.Timer();
            Timer_feed.Interval = 12;
            Timer_feed.Tick += new System.EventHandler(this.Event_update_tick); //Method attached
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
            Dt_trades_Execution.Columns.Add("ExitPrice", typeof(double));
            Dt_trades_Execution.Columns.Add("ExitTime", typeof(string));



            // bind with view
            dgv_trades.DataSource = Dt_trades_Execution;

        }

        private void Event_update_tick (object sender, EventArgs e)
        {
            get_live_tick();
        }


        private double get_live_tick()
        {
            double ltp = 0.0;
            try
            {

                ltp = Math.Round(random.NextDouble() * (21670 - 21650) + 21650, 2);
                //update_LTP_in_gui();
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


        private void update_trades_pnl()
        {

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
                newRow["ExitPrice"] = -1;
                newRow["ExitTime"] = -1;


                // Add the DataRow to the DataTable
                dt.Rows.Add(newRow);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Load Delegate : {ex.Message}");
            }
        }

        private void button1_starttradong_Click(object sender, EventArgs e)
        {
            if (mFlag_IStradingStarted == false)
            {
                //Start Trading mFlag_tradingStarted = True
                mFlag_IStradingStarted = true;

                Timer_feed.Start();
            }

        }

        private void button2_buy_Click(object sender, EventArgs e)
        {
            if(mFlag_IStradingStarted== true)
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