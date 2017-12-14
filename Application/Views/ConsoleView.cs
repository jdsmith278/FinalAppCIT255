using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;


namespace Application
{
    public static class ConsoleView
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        //
        // horizontal and vertical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ViewSettings.DISPALY_VERITCAL_MARGIN;

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        public static void DisplayTitleScreen()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                                                      -|Great People|-  ", System.Drawing.Color.DarkGoldenrod);
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");
            Console.WriteLine("                     ");



            DisplayContinuePromptInvisible();

            //System.Threading.Thread.Sleep(3000);
        }



        public static void DisplayContinuePrompt()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        public static void DisplayContinuePromptInvisible()
        {

            Console.ReadKey();
        }

        public static AppEnum.MenuOptions GetUserMenuOption()
        {
            DisplayReset();

            AppEnum.MenuOptions userMenuOption = AppEnum.MenuOptions.None;
            Console.WriteLine();
            Console.WriteLine("                                                     Enter a menu option.", System.Drawing.Color.CadetBlue);
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************************", System.Drawing.Color.CadetBlue);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



            Console.ForegroundColor = System.Drawing.Color.DarkKhaki;
            Console.WriteLine(
                "                                       1.            Display All Great People" + Environment.NewLine +
                "" + Environment.NewLine +
                "                                       2.            Display Great Person Detail" + Environment.NewLine +
                "" + Environment.NewLine +
                "                                       3.            Add a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "                                       4.            Delete a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "                                       5.            Update a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "                                       6.            Sort By Year Born");

            //"                                       7.            Query By");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = System.Drawing.Color.MediumVioletRed;
            Console.WriteLine("                                             Press 'E' to exit the application.");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("");
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userMenuOption = AppEnum.MenuOptions.ViewAllGreatPeople;
                    break;
                case '2':
                    userMenuOption = AppEnum.MenuOptions.DisplayGreatPersonDetail;
                    break;
                case '3':
                    userMenuOption = AppEnum.MenuOptions.AddGreatPerson;
                    break;
                case '4':
                    userMenuOption = AppEnum.MenuOptions.DeleteGreatPerson;
                    break;
                case '5':
                    userMenuOption = AppEnum.MenuOptions.UpdateGreatPerson;
                    break;
                case '6':
                    userMenuOption = AppEnum.MenuOptions.SortByDateBorn;
                    break;
                case '7':
                    userMenuOption = AppEnum.MenuOptions.QueryBy;
                    break;
                case 'e':
                case 'E':
                    userMenuOption = AppEnum.MenuOptions.Quit;
                    break;
                default:
                    break;
            }
            return userMenuOption;
        }

        /// <summary>
        /// method to display all Great Person info
        /// </summary>
        public static void DisplayAllGreatPeople(List<GreatPeople> greatPeople)
        {
            Console.Clear();

            StringBuilder columnHeader = new StringBuilder();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                    -|The Great People|-", System.Drawing.Color.DarkGoldenrod);
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************************", System.Drawing.Color.CadetBlue);

            Console.WriteLine();
            Console.WriteLine();

            columnHeader.Append("ID".PadRight(8));

            columnHeader.Append("Great Person".PadRight(25));

            //DisplayMessage(columnHeader.ToString());

            foreach (GreatPeople greatPerson in greatPeople)  /// uses greatPerson instead
            {
                StringBuilder greatPersonInfo = new StringBuilder();
                Console.ForegroundColor = System.Drawing.Color.DarkKhaki;
                greatPersonInfo.Append(greatPerson.ID.ToString().PadRight(8).PadLeft(57));
                Console.WriteLine();
                greatPersonInfo.Append(greatPerson.Name.PadRight(25));


                Console.WriteLine(greatPersonInfo);

            }
        }

        /// <summary>
        /// method to add a great persons info
        /// </summary>
        public static GreatPeople AddGreatPerson()
        {
            GreatPeople greatPeople = new GreatPeople();

            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = System.Drawing.Color.CadetBlue;
            Console.WriteLine(""); ;
            Console.WriteLine("                                                     Add A Great Person");
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************************");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter the Great Person ID: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.ID = ConsoleUtil.ValidateIntegerResponse("Please enter the Great Person ID: ", Console.ReadLine());

            Console.WriteLine("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter the Great Persons name: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.Name = Console.ReadLine();
            Console.WriteLine("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter what they are known for: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.KnownFor = Console.ReadLine();
            Console.WriteLine("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter the occupation: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.Occupation = Console.ReadLine();
            Console.WriteLine("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter the cause of death: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.NetWorth = Console.ReadLine();
            Console.WriteLine("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            Console.Write("                                                 Enter the year of birth: ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPeople.BirthYear =  Console.ReadLine();
            Console.WriteLine("");
            //Console.ForegroundColor = System.Drawing.Color.DimGray; //Description doesnt work atm
            //Console.WriteLine("  Enter a description: ");
            //greatPeople.Description = Console.ReadLine();
            Console.WriteLine("");

            return greatPeople;
        }
        public static int ValidateIntegerResponse(string promptMessage, string userResponse)
        {
            int userResponseInteger = 0;

            while (!(int.TryParse(userResponse, out userResponseInteger)))
            {
                ConsoleView.DisplayReset();

                ConsoleView.DisplayMessage("");
                ConsoleView.DisplayMessage("It appears you have not entered a valid integer.");

                ConsoleView.DisplayMessage("");
                ConsoleView.DisplayPromptMessage(promptMessage);
                userResponse = Console.ReadLine();
            }


            return userResponseInteger;
        }
        public static GreatPeople UpdateGreatPerson(GreatPeople greatPeople)
        {
            string userResponse = "";

            DisplayReset();
            Console.ForegroundColor = System.Drawing.Color.CadetBlue;
            DisplayMessage("");
            Console.WriteLine("                                                     Edit a Great Person");
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************************");

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayMessage(String.Format("Current Name: {0}", greatPeople.Name));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("                                  Enter a new name or just press Enter to keep the current name: ");
            Console.ResetColor();
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.Name = userResponse;
            }

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayMessage(String.Format("Reknowned Work: {0}", greatPeople.KnownFor));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("Enter a new Reknowned Work or just press Enter to keep the current Reknowned Work: ");
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.KnownFor = userResponse;
            }

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayMessage(String.Format("Occupation: {0}", greatPeople.Occupation));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("Enter a new occupation or just press Enter to keep the current occupation: ");
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.Occupation = userResponse;
            }

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayMessage(String.Format("Current cause of death: {0}", greatPeople.NetWorth));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("Enter a new cause of death or just press Enter to keep the current cause of death: ");
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.NetWorth = userResponse;
            }

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayMessage(String.Format("Current year of birth: {0}", greatPeople.BirthYear));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("Enter a new year of birth or just press Enter to keep the current year: ");
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.BirthYear = (userResponse);
            }

            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;

            DisplayMessage(String.Format("Description: {0}", greatPeople.Description));
            Console.ForegroundColor = System.Drawing.Color.ForestGreen;
            DisplayPromptMessage("Enter a new description or just press Enter to keep the current description: ");
            Console.ForegroundColor = System.Drawing.Color.DeepSkyBlue;
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.Description = (userResponse);
            }

            DisplayMessage("");

            DisplayContinuePrompt();

            return greatPeople;
        }

        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public static void DisplayReset()
        {
            //Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = System.Drawing.Color.DarkGoldenrod;
            //Console.BackgroundColor = System.Drawing.Color.BlueViolet;

            //Console.WriteLine(ConsoleUtil.FillStringWithSpaces(120));
            Console.WriteLine("                                                      -|Great People|-");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Console.WriteLine(ConsoleUtil.FillStringWithSpaces(119));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// method to get the users id choice
        /// </summary>
        public static int GetGreatPersonID(List<GreatPeople> greatPeople)
        {
            int greatPersonID = -1;

            DisplayMessage(" ");
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            DisplayPromptMessage("Enter the Great Persons ID:  ");
            Console.ForegroundColor = System.Drawing.Color.DeepPink;
            greatPersonID = ConsoleUtil.ValidateIntegerResponse("Please enter the Great Persons ID:  ", Console.ReadLine());

            return greatPersonID;
        }

        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }

        public static void DisplayGreatPerson(GreatPeople greatPeople)
        {
            Console.ResetColor();
            DisplayReset();


            DisplayMessage("");
            //Console.ForegroundColor = System.Drawing.Color.DarkSlateGray;
            Console.WriteLine("ID:               {0}", greatPeople.ID.ToString());
            Console.ResetColor();
            Console.ForegroundColor = System.Drawing.Color.Gold;
            Console.WriteLine("Details on the Great {1} {0}.", greatPeople.Name.ToString(), greatPeople.Occupation.ToString(), WINDOW_WIDTH);
            Console.ForegroundColor = System.Drawing.Color.Firebrick;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            DisplayMessage("");


            //DisplayMessage(String.Format("ID:               {0}", greatPeople.ID.ToString()));
            //Console.WriteLine();
            //DisplayMessage(String.Format("Great Person:     {0}", greatPeople.Name));
            //DisplayMessage("");

            DisplayMessage(String.Format("Name:             {0}", greatPeople.Name.ToString(), Console.ForegroundColor = System.Drawing.Color.DarkTurquoise));
            Console.WriteLine();
            DisplayMessage(String.Format("Occupation:       {0}", greatPeople.Occupation.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Known For:        {0}", greatPeople.KnownFor.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Year Born:        {0}", greatPeople.BirthYear.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Cause of Death:   {0}", greatPeople.NetWorth.ToString()));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = System.Drawing.Color.SpringGreen;
            DisplayMessage(String.Format("Description:      {0}", greatPeople.Description));

            DisplayMessage("");
        }

        public static void GetDateMinMaxValues(out int minimumDate, out int maximumDate)
        {
            minimumDate = 0;
            maximumDate = 0;
            ConsoleView.DisplayReset();
            ConsoleView.DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.CadetBlue;
            Console.WriteLine(ConsoleUtil.Center("                                Filter Great People By Year Born", 92));
            System.Console.WriteLine();
            System.Console.WriteLine("************************************************************************************************************************");
            ConsoleView.DisplayMessage("");
            Console.ResetColor();
            Console.ForegroundColor = System.Drawing.Color.DarkGoldenrod;
            ConsoleView.DisplayPromptMessage("Enter the minimum date: ");
            Console.ForegroundColor = System.Drawing.Color.Firebrick;
            string userResponse = Console.ReadLine();
            if (userResponse != "")
                minimumDate = ConsoleUtil.ValidateIntegerResponse("Please enter the minimum date using only numbers:", userResponse);
            Console.ResetColor();
            ConsoleView.DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.Gold;
            ConsoleView.DisplayPromptMessage("Enter the maximum date: ");
            Console.ForegroundColor = System.Drawing.Color.IndianRed;
            string userResponse2 = Console.ReadLine();
            if (userResponse2 != "")
                Console.ForegroundColor = System.Drawing.Color.Crimson;
            maximumDate = ConsoleUtil.ValidateIntegerResponse("Please enter the maximum date.", userResponse2);
            ConsoleView.DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.PaleGoldenrod;
            ConsoleView.DisplayMessage(string.Format("You have entered {0} as the minimum date and {1} as the maximum date.", (object)minimumDate, (object)maximumDate));
            ConsoleView.DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.MediumVioletRed;
            ConsoleView.DisplayContinuePrompt();
        }

        public static void DisplayQueryResults(IEnumerable<GreatPeople> datesGreatPeople)
        {
            Console.ResetColor();
            DisplayReset();
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("", WINDOW_WIDTH));
            DisplayMessage("");
            Console.ForegroundColor = System.Drawing.Color.CadetBlue;
            System.Console.WriteLine("                                        Here are the Great People you requested: ");
            System.Console.WriteLine();
            System.Console.WriteLine("************************************************************************************************************************");
            Console.ResetColor();
            DisplayMessage("");
            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(18));
            columnHeader.Append("Name".PadRight(35));
            columnHeader.Append("Year".PadRight(50));

            Console.ForegroundColor = System.Drawing.Color.Firebrick;

            DisplayMessage(columnHeader.ToString());
            foreach (GreatPeople greatPeople in datesGreatPeople)
            {
                StringBuilder greatPeopleInfo = new StringBuilder();
                Console.ForegroundColor = System.Drawing.Color.Goldenrod;
                greatPeopleInfo.Append(greatPeople.ID.ToString().PadRight(18));
                greatPeopleInfo.Append(greatPeople.Name.PadRight(35));
                greatPeopleInfo.Append(greatPeople.BirthYear.PadRight(50));

                DisplayMessage(greatPeopleInfo.ToString());
            }
        }


        #endregion
    }
}
