using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<Char>
    {
        private IList<char> characters = new List<char>();

        public StringDisperser(params string[] words)
        {
            AddCharacters(words);
        }

        public IList<char> Characters
        {
            get { return this.characters; }
        }

        private void DisperseString(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                this.characters.Add(word[i]);
            }
        }

        public void AddCharacters(params string[] words)
        {
            foreach (string word in words)
            {
                DisperseString(word);
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser other = obj as StringDisperser;
            if (other == null)
            {
                return false;
            }

            bool isEqual = this.Characters.SequenceEqual(other.Characters);

            if (!isEqual)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(StringDisperser sd1, StringDisperser sd2)
        {
            return Equals(sd1, sd2);
        }

        public static bool operator !=(StringDisperser sd1, StringDisperser sd2)
        {
            return !Equals(sd1, sd2);
        }

        public override string ToString()
        {
            string result = "";
            foreach (char character in this.Characters)
            {
                result += character + " ";
            }

            return result;
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (char character in this.Characters)
            {
                result ^= character.GetHashCode();
            }

            return result;
        }

        public object Clone()
        {
            StringDisperser cloning = new StringDisperser("");

            cloning.characters = new List<char>();
            foreach (char character in this.Characters)
            {
                cloning.characters.Add(character);
            }

            return cloning;
        }

        public int CompareTo(StringDisperser other)
        {
            string thisCharacters = string.Join("", this.Characters.ToArray());
            string otherCharacters = string.Join("", other.Characters.ToArray());

            return String.Compare(thisCharacters, otherCharacters, false, CultureInfo.CurrentCulture);
        }

        public IEnumerator<Char> GetEnumerator()
        {
            foreach (char character in this.Characters)
            {
                yield return character;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
