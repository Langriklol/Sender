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
            float BPM = float.Parse(json.header.bpm.ToString());
            this.json = json.tracks[1].notes.ToString();
            JArray toneArray = JArray.Parse(this.json);
            string currentName = "";
            float currentDuration = 0.0F;
            foreach(JObject jObject in toneArray.Children<JObject>())
            {
                if(jObject != null){
                foreach(JProperty toneProperty in jObject.Properties())
                {
                    if(toneProperty.Name.Equals("name")){
                        currentName = (string)toneProperty.Value;
                    }else if(toneProperty.Name.Equals("duration"))
                    {
                        currentDuration = float.Parse((string)toneProperty.Value);
                        //Let's do some Math!
                        currentDuration = 60/BPM*currentDuration*1000;
                    }else if(currentDuration != 0.0F && currentName != ""){
                        this.tones.Add(new Note(currentName, currentDuration));
                        currentName = "";
                        currentDuration = 0.0F;
                    }
                }
            }
            }
            return this.tones;
        }

        public string getJson()
        {
           string output = "{";
            foreach(Note note in this.tones)
            {
                output += String.Format(
                    "[\n" + " Name: {0} \n Frequency: {1} \n Duration: {2} ms\n" + "],\n",
                    note.getName(),
                    note.getFrequency(),
                    note.getDuration()
                   );
            }
            output += "}";
            return output;
        }
        public List<Note> getTones() => this.tones;
    }
}