using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("                                                     Great People");
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
            Console.WriteLine("                              Enter a menu option.");
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "              1.            Display All Great People" + Environment.NewLine +
                "" + Environment.NewLine +
                "              2.            Display Great Person Detail" + Environment.NewLine +
                "" + Environment.NewLine +
                "              3.            Add a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "              4.            Delete a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "              5.            Update a Great Person" + Environment.NewLine +
                "" + Environment.NewLine +
                "              6.            Sort By Occupation" + Environment.NewLine +
                "" + Environment.NewLine +
                "              7.            Query By");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                       Press 'E' to exit the application.");
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
                    userMenuOption = AppEnum.MenuOptions.QueryBy;
                    break;
                case '7':
                    userMenuOption = AppEnum.MenuOptions.SortBy;
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
            Console.WriteLine("                              The Great People");
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************");

            Console.WriteLine();
            Console.WriteLine();

            columnHeader.Append("ID".PadRight(8));

            columnHeader.Append("Great Person".PadRight(25));

            //DisplayMessage(columnHeader.ToString());

            foreach (GreatPeople greatPerson in greatPeople)  /// uses greatPerson instead
            {
                StringBuilder greatPersonInfo = new StringBuilder();
                Console.ForegroundColor = ConsoleColor.White;
                greatPersonInfo.Append(greatPerson.ID.ToString().PadRight(8).PadLeft(35));
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

            Console.WriteLine(""); ;
            Console.WriteLine("  Add A Great Person");
            Console.WriteLine("");

            Console.WriteLine("  Enter the Great Person ID: ");
            greatPeople.ID = ConsoleUtil.ValidateIntegerResponse("Please enter the Great Person ID: ", Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("  Enter the Great Persons name: ");
            greatPeople.Name = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("  Enter what they are known for: ");
            greatPeople.KnownFor = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("  Enter the occupation: ");
            greatPeople.Occupation = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("  Enter the cause of death: ");
            greatPeople.NetWorth = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("  Enter the year of birth: ");
            greatPeople.BirthYear = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("  Enter a description: ");
            greatPeople.Description = Console.ReadLine();
            Console.WriteLine("");

            return greatPeople;
        }

        public static GreatPeople UpdateGreatPerson(GreatPeople greatPeople)
        {
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Edit A Great Person ", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Current Name: {0}", greatPeople.Name));
            DisplayPromptMessage("Enter a new name or just press Enter to keep the current name: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.Name = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Reknowned Work: {0}", greatPeople.KnownFor));
            DisplayPromptMessage("Enter a new Reknowned Work or just press Enter to keep the current Reknowned Work: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.KnownFor = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Occupation: {0}", greatPeople.Occupation));
            DisplayPromptMessage("Enter a new occupation or just press Enter to keep the current type: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.Occupation = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current cause of death: {0}", greatPeople.NetWorth));
            DisplayPromptMessage("Enter a new cause of death or just press Enter to keep the current cause of death: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.NetWorth = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current year of birth: {0}", greatPeople.BirthYear));
            DisplayPromptMessage("Enter a new year of birth or just press Enter to keep the current year: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                greatPeople.BirthYear = (userResponse);
            }

            DisplayMessage("");


            DisplayMessage(String.Format("Description: {0}", greatPeople.Description));
            DisplayPromptMessage("Enter a new description or just press Enter to keep the current description: ");
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
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Great People", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// method to get the users id choice
        /// </summary>
        public static int GetGreatPersonID(List<GreatPeople> greatPeople)
        {
            int greatPersonID = -1;

            DisplayMessage("");
            DisplayPromptMessage("Enter the Great Persons ID: ");

            greatPersonID = ConsoleUtil.ValidateIntegerResponse("Please enter the Great Persons ID: ", Console.ReadLine());

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
            DisplayReset();

            DisplayMessage("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("ID:               {0}", greatPeople.ID.ToString());
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Details on the Great {1} {0}.", greatPeople.Name.ToString(), greatPeople.Occupation.ToString(), WINDOW_WIDTH);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.ResetColor();
            DisplayMessage("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            //DisplayMessage(String.Format("ID:               {0}", greatPeople.ID.ToString()));
            //Console.WriteLine();
            //DisplayMessage(String.Format("Great Person:     {0}", greatPeople.Name));
            //DisplayMessage("");

            DisplayMessage(String.Format("Name:             {0}", greatPeople.Name.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Occupation:       {0}", greatPeople.Occupation.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Known For:        {0}", greatPeople.KnownFor.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Year Born:        {0}", greatPeople.BirthYear.ToString()));
            Console.WriteLine();
            DisplayMessage(String.Format("Cause of death:   {0}", greatPeople.NetWorth.ToString()));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            DisplayMessage(String.Format("Description:      {0}", greatPeople.Description));

            DisplayMessage("");
        }
        #endregion
    }
}
