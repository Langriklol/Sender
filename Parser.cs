using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;

namespace Sender{
    public class Parser{
        private List<Note> tones = new List<Note>();
        private string json;
        public Parser()
        {
        }

        public List<Note> Parse(string path)
        {
            dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(path));
            //json = json.tracks;
            this.json = json.tracks[1].notes.ToString();
            JArray toneArray = JArray.Parse(this.json);
            foreach(JObject jObject in toneArray.Children<JObject>())
            {
                string currentName = "";
                string currentDuration = "";
                foreach(JProperty toneProperty in jObject.Properties())
                {
                    if(toneProperty.Name.Equals("name")){
                        currentName = (string)toneProperty.Value;
                    }else if(toneProperty.Name.Equals("duration"))
                    {
                        currentDuration = (string)toneProperty.Value;
                    }else if(currentDuration != "" && currentName != ""){
                        this.tones.Add(new Note(currentName, float.Parse(currentDuration)));
                        currentName = "";
                        currentDuration = "";
                    }
                }
            }
            return this.tones;
        }

        public string getJson()
        {
           string output = "";
            foreach(Note note in this.tones)
            {
                output += String.Format("{\n" + "Name: {0} \n Frequency: {1} \n Duration: {2} \n" + "}",
                 note.getName(), note.getFrequency(), note.getDuration());
            }
            return output;
        }

        public System.Type getJsonType() => this.json.GetType();

        //public List<Note> getTones() => this.tones;
    }
}