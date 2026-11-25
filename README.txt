Smash House POS - Windows Forms (CS 312)

Run: open FastFoodPOS.csproj in Visual Studio 2022 (.NET 8, Windows Forms) and press F5.
To edit a screen: double-click XxxForm.cs in Solution Explorer (it opens in the Designer).

Log in:
  admin   / admin123    -> New order, Menu manager, Order history, Reports
  cash    / cash123     -> New order, Order history
  kitchen / kitchen123  -> Kitchen display only

All data is kept in memory (DataStore.cs) while the program runs; nothing is written to disk
except what you export yourself (CSV report, PNG chart, PNG receipt).

Shortcuts: Main: Ctrl+N new order, Ctrl+H history, Ctrl+R reports, F1 about.
           Order: Ctrl+F search, Ctrl+Enter checkout, Delete removes the selected line, Esc closes.
           Reports: F5 generate.   Every other screen: Esc closes.

See SUBMISSION_NOTES.md for where each required component is implemented.
