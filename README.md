# Trading Simulation Project
## Introduction

This project aims to simulate a trading environment, providing users with a realistic experience of a trading platform.
This README will guide you through the initial setup and explain the first screen of the simulation.

### User Authentication
This is the first screen of the trading simulation, where user credentials are validated. The screen contains the following components:

- **User ID Field:** Input field for the user's identification.
- **Password Field:** Input field for the user's password.
- **Submit Button:** Event triggered when the user wants to submit the credentials.
- **Exit/Cancel Button:** Event triggered when the user wants to exit or cancel the authentication process.

<img width="263" alt="login Panel" src="https://github.com/Coderixc/Trading-Simulation/assets/40321363/b07dffad-8d9a-4e1e-b28d-ec30bd5864cf">


After successfully validating the user credentials, users can proceed to explore the trading simulation. Refer to the documentation for detailed information on using the various features and functionalities.




### 2 Layout

The second screen of the trading simulation opens once the user is successfully validated. It features different layouts for:

- **Charting:** (Note: Charting functionality is not completed due to the removal of Charting Control from .Net 3.0 by Microsoft.)
- **Trades Execution:** Contains columns for various trade-related information.
- **Log Forms:** Display logs of trading activities.

### Buttons

The second layout includes the following buttons:

- **Start Trading:** Initiates the trading functionality after validating specific conditions.
- **BUY:** Initiates the buying process for one STOCKS NIFTY 50, generating a random tick price using the Random class.
- **SELL:** Initiates the selling process for one STOCKS NIFTY 50, generating a random tick price using the Random class.

### Trading Conditions

Before activating the "Start Trading" functionality, the system checks specific conditions to ensure a safe and controlled trading environment. 

### Trades Execution View

The Trades Execution view contains different columns, each performing specific functions:

- **Symbol:** Indicates the trading instrument (e.g., STOCKS NIFTY 50).
- **Quantity:** Represents the quantity of stocks traded.
- **Price:** Displays the trade price.
- **OrderType:** Specifies the trading action (BUY/SELL).
- **EntryTime:**  Entry Time of Trades
- **Status:**  Open/ Close
- **Ltp:**  Ltp Tick of Stocks
- **PnL:**  Calculate PNL
- **ExitPrice:** Exit Price
- **ExitTime:** Exit Time of Trades  

<img width="1326" alt="Welcome Screen" src="https://github.com/Coderixc/Trading-Simulation/assets/40321363/0e48185f-4a38-4681-ac92-2c3ce1f2d141">


### 3 Layout
## Tick Update and Trade Generation

Once the user is allowed to start trading, ticks will be updated and visible in a text box. Users can generate new trades using the "Buy" and "Sell" buttons. The tick price will be generated randomly .
## Buttons

- **Buy:** Initiates the buying process, generating a random tick price.
- **Sell:** Initiates the selling process, generating a random tick price.

### Tick Update

The updated tick price will be displayed in a text box, providing real-time information to the user about the market conditions.
Explore the tick updating, trade generation, and P&L calculation features on the trading screen. Experiment with buying and selling to observe how the P&L is dynamically calculated based on market movements (Random function  will simulate Market real time feed)



<img width="1067" alt="Trading screen 3" src="https://github.com/Coderixc/Trading-Simulation/assets/40321363/9f5763cf-d538-488e-a539-fa1bc2e7c7ce">
