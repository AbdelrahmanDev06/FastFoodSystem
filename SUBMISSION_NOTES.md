# Smash House POS - Submission notes

Project: `FastFoodPOS` (C#, .NET 8, Windows Forms). Open `FastFoodPOS.csproj` and run.

## 1. Windows Forms Controls & Event Handling

| Topic (Lab) | Where |
|---|---|
| Buttons, TextBox, CheckBox, RadioButton, ComboBox, NumericUpDown, DateTimePicker, DataGridView, GroupBox, TabControl, FlowLayoutPanel, MenuStrip, ToolStrip, StatusStrip | Designer files of all screens |
| Click events, shared handler using `sender` | `OrderForm.Tile_Click` (all tiles), `Extra_CheckedChanged` (all extras), `HistoryForm.Payment_CheckedChanged` (3 radios), `MenuManagerForm.PriceBox_KeyPress` (2 boxes), `MainForm.NewOrder_Click` (menu + button + toolbar) |
| Dynamic controls created at run time (`new`, `+=`, `Controls.Add`, `Dispose`) | `OrderForm.RefreshMenu`, `BuildExtraBoxes`; `KitchenForm.AddTicket`; `ReceiptForm` |
| Custom / reusable controls | `MenuTile : Button`, `DoubleBufferedPanel : Panel` |
| Keyboard: `KeyDown`, `KeyPress`, `KeyPreview`, `AcceptButton` | `OrderForm_KeyDown`, `dgvCart_KeyDown`, `txtOrderId_KeyPress`, `PriceBox_KeyPress`, `MainForm_KeyDown`, `HistoryForm` (Enter = Search) |
| Mouse: `MouseEnter/Leave`, `MouseMove` | `Tile_MouseEnter/Leave`, `ReportsForm.pnlBar_MouseMove`, `pnlPie_MouseMove` |
| Timer events | `MainForm.tmrClock_Tick`, `KitchenForm.tmrAge_Tick`, `ReportsForm.tmrAnim_Tick`, `AboutForm.tmrSpin_Tick` |
| Cancelable events (`FormClosing`, `e.Cancel`) | `OrderForm_FormClosing` (unsent order), `MainForm_FormClosing` (exit question) |
| Validation + `MessageBox` | Checkout, Menu manager Add/Update, date range checks |
| Selection events + master/detail | `dgvCart_SelectionChanged`, `dgvOrders_SelectionChanged`, `dgvItems_SelectionChanged` |
| Role-based UI | `MainForm_Load`, `HistoryForm.ShowLines` (only admin may delete) |
| Working data flow | `DataStore.cs`: order -> history -> kitchen ticket -> reports |

## 2. GDI+ / Graphics / Visualization

| Topic (Lab 7/8) | Where |
|---|---|
| `Paint` event, `Graphics`, `Pen`, `Brush`, `Font`, `DrawString` | `ReportsForm.pnlBar_Paint`, `pnlPie_Paint` |
| Lines, rectangles, ellipses, polygons, pies, curves | Bar chart + grid, pie chart, `Gfx.DrawBurger` |
| Gradient brushes, `ColorBlend`, `GraphicsPath` (rounded rectangles), anti-aliasing | bars, `KitchenForm.AgeBar_Paint`, `Gfx.RoundedRect`, tooltips |
| Transformations (`Translate`, `Rotate`, `Save/Restore`) | `AboutForm.pnlLogo_Paint` (rotating ring), hovered pie slice, VOID stamp in `ReceiptRenderer` |
| Timer animation | bars/pie grow (`tmrAnim`), spinning logo (`tmrSpin`) |
| Interactive graphics (mouse hit-testing) | hover bar / pie slice with tooltip |
| Double buffering | `DoubleBufferedPanel` used by charts, logo, receipt, kitchen bar |
| Drawing into a `Bitmap`, saving PNG | right-click chart -> "Save chart as PNG"; `ReceiptForm.btnSaveImage_Click` |
| Data visualisation from real data | charts are calculated from `DataStore.Orders` for the chosen date range |
| Custom painted control | `MenuTile.OnPaint` (category colour stripe) |
| Receipt drawn with GDI+ | `ReceiptRenderer.Draw` (after checkout and Order history -> Reprint receipt) |

## Quick test (5 minutes)
1. Log in as `admin`. **New order**: click tiles, tick extras, change quantity, Delete key, Checkout -> receipt appears.
2. **Order history**: your order is on top; Void it (grey + VOID stamp on the receipt); Restore it.
3. **Reports**: Generate with different dates; hover bars and slices; right-click a chart -> save PNG; Export CSV.
4. **Menu manager**: add an item, set it unavailable, rename a category, add an add-on, then check the Order screen.
5. Log out, log in as `kitchen`: the new ticket is there; Done removes it. Help -> About shows the spinning logo.

## Honest note
The code was written and checked statically (all handlers wired, all controls declared) but could not be compiled
in the authoring environment. If Visual Studio reports an error, send it and it is a one-line fix.
