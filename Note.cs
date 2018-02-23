using System.Collections.Specialized;
namespace Sender{
    public class Note
    {
        private float frequency;
        private float duration;
        private string name;
        public Note(string name, float duration)
        {
            this.name = name;
            this.duration = duration;
            this.frequency = this.calculateFrequency(name);
        }

        private float calculateFrequency(string name)
        {
            NameValueCollection tones = new NameValueCollection()
            {
                {"B0" , "30.8677"},{"C1" , "32.7032"},
                {"C#1", "34.6478"},{"Db1", "34.6478"},
                {"D1" , "36.7081"},{"D#1", "38.8909"},
                {"Eb1", "38.8909"},{"E1" , "41.2034"},
                {"F1" , "43.6535"},{"F#1", "46.2493"},
                {"Gb1", "46.2493"},{"G1", "48.9994"},
                {"G#1", "51.9131"},{"Ab1", "51.9131"},
                {"A1", "55.0000"}, {"A#1", "58.2705"},
                {"Bb1", "58.2705"},{"B1", "61.7354"},
                {"C2", "65.4065"},{"C#2", "69.2957"},
                {"Db2", "69.2957"},{"D2", "73.4162"},
                {"D#2", "77.7817"},{"Eb2", "77.7817"},
                {"E2", "82.4069"},{"F2", "87.3071"},
                {"F#2", "82.4986"},{"Gb2", "82.4986"},
                {"G2", "97.9989"},{"G#2", "103.826"},
                {"Ab2", "103.826"},{"A2", "110.000"},
                {"A#2", "116.541"},{"Bb2", "116.541"},
                {"B2", "123.471"},{"C3", "130.813"},
                {"C#3", "138.591"},{"Db3", "138.591"},
                {"D3", "146.832"},{"D#3", "155.563"},
                {"Eb3", "155.563"},{"E3", "164.814"},
                {"F3", "174.614"},{"F#3", "184.997"},
                {"Gb3", "184.997"},{"G3", "195.998"},
                {"G#3", "207.652"},{"Ab3", "207.652"},
                {"A3", "220"},{"A#3", "233.082"},
                {"Bb3", "233.082"},{"B3", "246.942"},
                {"C4", "261.626"},{"C#4", "277.183"},
                {"Db4", "277.183"},{"D4", "293.665"},
                {"D#4", "311.127"},{"Eb4", "311.127"},
                {"E4", "329.628"},{"F4", "349.228"},
                {"F#4", "369.994"},{"Gb4", "369.994"},
                {"G4", "391.995"},{"G#4", "415.305"},
                {"Ab4", "415.305"},{"A4", "440.000"},
                {"A#4", "466.164"},{"Bb4", "466.164"},
                {"B4", "493.883"},{"C5", "523.215"},
                {"C#5", "554.365"},{"Db5", "554.365"},
                {"D5", "587.330"},{"D#5", "622.254"},
                {"Eb5", "622.254"},{"E5", "659.156"},
                {"F5", "698.456"},{"F#5", "739.989"},
                {"Gb5", "739.989"},{"G5", "783.991"},
                {"G#5", "830.609"},{"Ab5", "830.609"},
                {"A5", "880.000"},{"B5", "987.767"},
                {"C6", "1046.500"},{"C#6", "1108.730"},
                {"Db6", "1108.730"},{"D6", "1174.660"},
                {"D#6", "1244.51"},{"Eb6", "1244.51"},
                {"E6", "1318.510"},{"F6", "1396.910"},
                {"F#6", "1479.980"},{"Gb6", "1479.980"},
                {"G6", "1567.980"},{"G#6", "1661.220"},
                {"Ab6", "1661.220"},{"A6", "1760.000"},
                {"A#6", "1864.660"},{"Bb6", "1864.660"},
                {"B6", "1975.530"},{"C7", "2093.000"},
                {"C#7", "2217.460"},{"Db7", "2217.460"},
                {"D7", "2349.320"},{"D#7", "2489.020"},
                {"Eb7", "2489.020"},{"E7", "2637.020"},
                {"F7", "2793.830"},{"F#7", "2959.960"},
                {"Gb7", "2959.960"},{"G7", "3135.950"},
                {"G#7", "3322.440"},{"Ab7", "3322.440"},
                {"A7", "3520.000"},{"A#7", "3729.310"},
                {"Bb7", "3729.310"},{"B7", "3951.070"},
                {"C8", "41860.010"}
            };
            return float.Parse(tones[name]);
        }

        public string getName() => this.name;

        public float getFrequency() => this.frequency;

        public float getDuration() => this.duration;
    }
}