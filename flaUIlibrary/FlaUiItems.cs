using System;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System.IO;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using FlaUI.Core;
using FlaUI.Core.WindowsAPI;

namespace flaUIlibrary
{
    public class FlaUiItems : IFlaUiItems
    {

        private Window window;
        private Application app;

        public void Launch()
        {
            app = FlaUI.Core.Application.Launch("mspaint.exe");
            var automation = new UIA3Automation();
            using (automation)
            {
                window = app.GetMainWindow(automation);
            }

        }

        public void Help()
        {
            string[] arr = new string[] { "Launch", "Kill", "Exit", "Help", "Open", "Download", "Close", "StartNew", "TypeText", "DrawShape"};
            Console.WriteLine(); Console.WriteLine("Possible commands are:");
            Console.WriteLine(String.Join("\n", arr));
            Console.WriteLine();
        }

        public void Open()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var automation = new UIA3Automation();

            Console.WriteLine("Enter path to file (including file name with extension):");
            string filepath = Console.ReadLine();
            
            var fileButton = window.FindFirstDescendant(cf.ByName("File tab")).AsButton();
            fileButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var openButton = window.FindFirstDescendant(cf.ByName("Open")).AsButton();
            openButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            app.GetAllTopLevelWindows(automation);
            var fileBox = window.FindFirstDescendant(cf.ByAutomationId("1148")).AsComboBox();
            Keyboard.Type(filepath);

            System.Threading.Thread.Sleep(2000);

            Keyboard.Type(VirtualKeyShort.ENTER);

        }

        public void Download()
        {
            var downloadsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");


            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var fileButton = window.FindFirstDescendant(cf.ByName("Save")).AsButton();
            fileButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var saveButton = window.FindFirstDescendant(cf.ByName("Save")).AsButton();
            saveButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var yesButton = window.FindFirstDescendant(cf.ByAutomationId("CommandButton_6"))?.AsButton();
            yesButton?.Invoke();
        }

        public void MyClose()
        {
            Download();
            app.Close();
        }


        public void Kill()
        {
            app.Kill();
        }
        public void StartNew() //***
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var fileTab = window.FindFirstDescendant(cf.ByText("File tab"))?.AsButton();
            fileTab?.Invoke();
            
            System.Threading.Thread.Sleep(2000);

            var newButton = window.FindFirstDescendant(cf.ByText("New"))?.AsMenuItem();
            newButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var saveButton = window.FindFirstDescendant(cf.ByAutomationId("CommandButton_6"))?.AsButton();
            saveButton?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var saveButton2 = window.FindFirstDescendant(cf.ByText("Save"))?.AsButton();
            saveButton2?.Invoke();

            System.Threading.Thread.Sleep(2000);

            var yesButton = window.FindFirstDescendant(cf.ByAutomationId("CommandButton_6"))?.AsButton();
            yesButton?.Invoke();
            
        }

        public void TypeText()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            Console.WriteLine("Enter text:");
            string textString = Console.ReadLine();

            var textButton = window.FindFirstDescendant(cf.ByName("Text")).AsButton();
            textButton?.Invoke();

            Random x = new Random();
            int xCord = x.Next(7, 822);

            Random y = new Random();
            int yCord = y.Next(145, 600);

            Point point = new Point(xCord, yCord);
            Mouse.LeftClick(point);

            window.FindFirstDescendant(cf.ByName("Text edit box")).AsTextBox().Enter(textString);

            Point exitPoint = new Point(817, 593);
            Mouse.LeftClick(exitPoint);
            
        }

        public void DrawShape()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            Console.WriteLine("Enter shape name:");
            string textString = Console.ReadLine();

            var shapeButton = window.FindFirstDescendant(cf.ByName(textString)).AsButton();
            shapeButton?.Invoke();

            Random x = new Random();
            int xCord = x.Next(7, 822);

            Random y = new Random();
            int yCord = y.Next(145, 600);

            Random x2 = new Random();
            int x2Cord = x2.Next(7, 822);

            Random y2 = new Random();
            int y2Cord = y2.Next(145, 600);



            Point point = new Point(xCord, yCord);
            Point point2 = new Point(x2Cord, y2Cord);
            Mouse.Drag(point, point2, MouseButton.Left);


            Point exitPoint = new Point(817, 593);
            Mouse.LeftClick(exitPoint);

        }
    }
}
