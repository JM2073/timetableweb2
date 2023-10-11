using BlazorApp1.Data;
using Newtonsoft.Json;

namespace BlazorApp1
{
    public class LectureControls
    {
        string doc = "Data/Lecture.json";
        public void AddLecture(string CourseName,string ModuleCode, string ModuleName, string LecturerName, int RoomNumber, string DayOfTheWeek, DateTime StartTime, DateTime EndTime, string id)
        {
           
            //get data __ user input 
            var lecture = new Lecture
            {
                courseName = CourseName,
                moduleCode = ModuleCode,
                moduleName = ModuleName,
                lecturerName = LecturerName,
                roomNumber = RoomNumber,
                dayOfTheWeek = DayOfTheWeek,
                startTime = StartTime,
                endTime = EndTime,
                ID = id
            };
            
            // get all data from json 
            List<Lecture> existingJson = new List<Lecture>();
            if (File.Exists(doc))
            {
                string jsonText = File.ReadAllText(doc);
                existingJson = JsonConvert.DeserializeObject<List<Lecture>>(jsonText);
            }
            //add new data and write back to json
             existingJson.Add(lecture);
            string updatedJson = JsonConvert.SerializeObject(existingJson, Formatting.Indented);
            File.WriteAllText(doc, updatedJson);
        }

        public void UpdateLecture(string CourseName, string ModuleCode, string ModuleName, string LecturerName, int RoomNumber, string DayOfTheWeek, DateTime StartTime, DateTime EndTime, string ID)
        {
            string jsonText = File.ReadAllText(doc);
            List<Lecture>? existingJson = JsonConvert.DeserializeObject<List<Lecture>>(jsonText);

            foreach (Lecture json in existingJson)
            {
                if (json.ID == ID)
                {
                    json.courseName = CourseName;
                    json.moduleCode = ModuleCode;
                    json.moduleName = ModuleName;
                    json.roomNumber = RoomNumber;
                    json.lecturerName = LecturerName;
                    json.dayOfTheWeek = DayOfTheWeek;
                    json.startTime = StartTime;
                    json.endTime = EndTime;
                    json.ID = ID;
                }
            }

            string updatedJson = JsonConvert.SerializeObject(existingJson, Formatting.Indented);
              File.WriteAllText(doc, updatedJson);
}

        public void DeleteLecture(string ID)
        {
            string jsonText = File.ReadAllText(doc);
            List<Lecture>? existingJson = JsonConvert.DeserializeObject<List<Lecture>>(jsonText);

            existingJson.Remove(existingJson.Single(x => x.ID == ID));
                
            string updatedJson = JsonConvert.SerializeObject(existingJson,Formatting.Indented);

            File.WriteAllText(doc, updatedJson);

        }
        
        /// <summary>
        /// calling this method will search all possible fields and return a list of all matching results.   
        /// </summary>
        /// <param name="lectures">pass though the oringal array of lectures</param>
        /// <param name="searchTerm">the term that is being searched by</param>
        /// <returns>a list of results</returns>
        public Lecture[]? SearchLectures(Lecture[] lectures, string searchTerm)
        {
            Lecture[] result = new Lecture[]{};

            result = lectures.Where(x =>
                x.courseName.Contains(searchTerm)  ||
                x.moduleName.Contains(searchTerm) ||
                x.lecturerName.Contains(searchTerm) ||
                x.roomNumber.ToString().Contains(searchTerm)||
                x.moduleCode.Contains(searchTerm)).ToArray();
        
            return result;
        }
  
    }
}
