using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Application
{
    public class Controller
    {

        #region Fields

        bool active = true;

        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Controller()
        {
            ApplicationLoop();
        }

        #endregion

        #region Methods
        private void ApplicationLoop()
        {
            AppEnum.MenuOptions userMenuChoice;

            ConsoleView.DisplayTitleScreen();

            while (active)
            {

                userMenuChoice = ConsoleView.GetUserMenuOption();

                switch (userMenuChoice)
                {
                    case AppEnum.MenuOptions.ViewAllGreatPeople:
                        ListAllGreatPeople();
                        break;

                    case AppEnum.MenuOptions.DisplayGreatPersonDetail:
                        DisplayGreatPersonDetail();
                        break;

                    case AppEnum.MenuOptions.AddGreatPerson:
                        AddGreatPerson();
                        break;

                    case AppEnum.MenuOptions.DeleteGreatPerson:
                        DeleteGreatPerson();
                        break;

                    case AppEnum.MenuOptions.UpdateGreatPerson:
                        UpdateGreatPerson();
                        break;

                    case AppEnum.MenuOptions.SortByDateBorn:
                        QueryByDateBorn();
                        break;

                    case AppEnum.MenuOptions.QueryBy:

                        break;

                    case AppEnum.MenuOptions.Quit:
                        active = false;
                        break;

                    default:
                        break;
                }
            }


        }

        private static void QueryByDateBorn()
        {
            GreatPeopleRepositorySQL greatPeopleRepository = new GreatPeopleRepositorySQL();
            IEnumerable<GreatPeople> matchingDate = new List<GreatPeople>();
            int minimumDate;
            int maximumDate;

            ConsoleView.GetDateMinMaxValues(out minimumDate, out maximumDate);

            using (greatPeopleRepository)
            {
                matchingDate = greatPeopleRepository.QueryByDateBorn(minimumDate, maximumDate);
            }

            ConsoleView.DisplayQueryResults(matchingDate);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = System.Drawing.Color.LawnGreen;
            ConsoleView.DisplayContinuePromptInvisible();
        }
        private static void ListAllGreatPeople()
        {
            GreatPeopleRepositorySQL greatPersonRepository = new GreatPeopleRepositorySQL();
            List<GreatPeople> greatPeople;

            using (greatPersonRepository)
            {
                greatPeople = greatPersonRepository.SelectAll();
                ConsoleView.DisplayAllGreatPeople(greatPeople);
                ConsoleView.DisplayContinuePromptInvisible();
            }
        }

        private static void DisplayGreatPersonDetail()
        {
            GreatPeopleRepositorySQL greatPeopleRepository = new GreatPeopleRepositorySQL();
            List<GreatPeople> greatPeople;
            GreatPeople greatPerson = new GreatPeople();
            int greatPersonID;

            using (greatPeopleRepository)
            {
                greatPeople = greatPeopleRepository.SelectAll();
                greatPersonID = ConsoleView.GetGreatPersonID(greatPeople);
                greatPerson = greatPeopleRepository.SelectById(greatPersonID);
            }

            ConsoleView.DisplayGreatPerson(greatPerson);
            ConsoleView.DisplayContinuePromptInvisible();
        }

        private static void AddGreatPerson()
        {
            GreatPeopleRepositorySQL greatPersonRepository = new GreatPeopleRepositorySQL();
            GreatPeople greatPerson = new GreatPeople();

            greatPerson = ConsoleView.AddGreatPerson();
            using (greatPersonRepository)
            {
                greatPersonRepository.Insert(greatPerson);
            }

            //ConsoleView.DisplayContinuePromptInvisible();
        }

        private static void DeleteGreatPerson()
        {
            GreatPeopleRepositorySQL greatPeopleRepository = new GreatPeopleRepositorySQL();
            List<GreatPeople> greatPeople = greatPeopleRepository.SelectAll();
            GreatPeople greatPerson = new GreatPeople();
            int greatPersonID;
            string message;

            greatPersonID = ConsoleView.GetGreatPersonID(greatPeople);

            using (greatPeopleRepository)
            {
                greatPeopleRepository.Delete(greatPersonID);
            }

            ConsoleView.DisplayReset();

            message = String.Format("Great Person ID: {0} had been deleted.", greatPersonID);

            ConsoleView.DisplayMessage(message);
            ConsoleView.DisplayContinuePromptInvisible();
        }

        private static void UpdateGreatPerson()
        {
            GreatPeopleRepositorySQL greatPeopleRepository = new GreatPeopleRepositorySQL();
            List<GreatPeople> greatPerson = greatPeopleRepository.SelectAll();
            GreatPeople greatPeople = new GreatPeople();
            int greatPersonID;

            using (greatPeopleRepository)
            {
                greatPerson = greatPeopleRepository.SelectAll();
                greatPersonID = ConsoleView.GetGreatPersonID(greatPerson);
                greatPeople = greatPeopleRepository.SelectById(greatPersonID);
                greatPeople = ConsoleView.UpdateGreatPerson(greatPeople);
                greatPeopleRepository.Update(greatPeople);
            }
        }

        #endregion
    }
}
