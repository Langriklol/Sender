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
            
            List<Note> helper = new List<Note>();

            string currentName = "";
            float currentDuration = 0.0F;
            float timeElapsed = 0.0F;
            float startNoteTime = 0.0F;
            bool elapsed = false;

            foreach(JObject jObject in toneArray.Children<JObject>())
            {
                if(jObject != null){
                    foreach(JProperty toneProperty in jObject.Properties())
                    {
                        if(toneProperty.Name.Equals("name"))
                        {
                            currentName = (string) toneProperty.Value;
                        }else if(toneProperty.Name.Equals("duration"))
                        {
                            currentDuration = float.Parse((string)toneProperty.Value);
                        }else if(toneProperty.Name.Equals("time"))
                        {
                            startNoteTime = float.Parse((string)toneProperty.Value);
                            if(!elapsed)
                            {
                                elapsed = false;
                                timeElapsed = startNoteTime;
                            }
                        }else if(currentName != "" && timeElapsed != 0 && currentDuration != 0)
                        {
                            Note note = new Note(currentName, currentDuration*1000, startNoteTime);
                            if(note.getTime() == timeElapsed)
                            {
                                this.tones.Add(note);
                                timeElapsed += currentDuration;
                            }else
                            {
                                float difference = note.getTime() - timeElapsed;
                                this.tones.Add(new Note("P1", Math.Abs(difference*1000)));
                                this.tones.Add(note);
                                timeElapsed += difference;
                            }
                        }else
                        {
                            continue;
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
                    "[\n" + " Name: {0} \n Frequency: {1} Hz\n Duration: {2} ms\n" + "],\n",
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