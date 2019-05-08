# CascadingDropdownlist

Cascading Dropdownlist Example

System Requirement: Visual Studio, SQL Server and EF

#Select and Where Example


    public class StudentViewModel
    {
        public static SelectList GetAllCountries()
        {
            List<SelectListItem> countries = new List<SelectListItem>();

            using (StudentDBContext db = new StudentDBContext())
            {
                countries = db.Countries.Select(x => new SelectListItem
                            {
                                Value = x.CountryId.ToString(),
                                Text = x.Country1
                            }).ToList();
            }

            SelectList selectList = new SelectList(countries.AsEnumerable(), "Value", "Text");

            return selectList;
        }

        public static SelectList GetStatesAccordingToCountries(int countryId)
        {
            List<SelectListItem> states = new List<SelectListItem>();

            using (StudentDBContext db = new StudentDBContext())
            {
                states = db.States
                        .Where(x => x.CountryId == countryId)
                        .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName }).ToList();
            }

            SelectList selectList = new SelectList(states.AsEnumerable(), "Value", "Text");

            return selectList;
        }

        public static SelectList GetCitiesAccordingToStates(int stateId)
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            using (StudentDBContext db = new StudentDBContext())
            {
                cities = db.Cities
                        .Where(x => x.StatedId == stateId)
                        .Select(x => new SelectListItem { Value = x.CityId.ToString(), Text = x.CityName }).ToList();
            }

            SelectList selectList = new SelectList(cities.AsEnumerable(), "Value", "Text");

            return selectList;
        }
    }
