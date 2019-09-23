using System;
using System.Collections.Generic;
using System.Xml;
using Block = System.Collections.Generic.List<bool>;

namespace ChanUpP.Manage
{
    public class Converter
    {
        private Dictionary<char, Block> Braille = new Dictionary<char, Block>();
        private Block ListToBlock(List<int> vs)
        {
            var p = new Block();

            foreach (var e in vs)
            {
                p.Add(e != 0);
            }
            return p;
        }
        private List<char> CharToSplit(char str)
        {
            List<char> result = new List<char>();

            //초성
            var wcHead = new char[]
            { 'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ',
                'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ',
                'ㅃ', 'ㅅ', 'ㅆ', 'ㅇ',
                'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ',
                'ㅌ', 'ㅍ', 'ㅎ'
            };

            //중성
            var wcMid = new char[]{'ㅏ', 'ㅐ', 'ㅑ', 'ㅒ',
                'ㅓ', 'ㅔ', 'ㅕ', 'ㅖ',
                'ㅗ', 'ㅘ', 'ㅙ', 'ㅚ',
                'ㅛ', 'ㅜ', 'ㅝ', 'ㅞ',
                'ㅟ', 'ㅠ', 'ㅡ', 'ㅢ', 'ㅣ'};

            //종성
            var wcTail = new char[]{' ', 'ㄱ', 'ㄲ', 'ㄳ',
                'ㄴ', 'ㄵ', 'ㄶ', 'ㄷ',
                'ㄹ', 'ㄺ', 'ㄻ', 'ㄼ',
                'ㄽ', 'ㄾ', 'ㄿ', 'ㅀ',
                'ㅁ', 'ㅂ', 'ㅄ', 'ㅅ',
                'ㅆ', 'ㅇ', 'ㅈ', 'ㅊ',
                'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ'};

            if (str < 256)
            {
                result.Add(str);
            }
            else
            {
                result.Add(wcHead[(str - 0xAC00) / (21 * 28)]);
                result.Add(wcMid[(str - 0xAC00) % (21 * 28) / 28]);

                if (wcTail[(str - 0xAC00) % 28] != ' ')
                {
                    result.Add(wcTail[(str - 0xAC00) % 28]);
                }
            }
            return result;
        }
        public Converter()
        {
            Braille['ㄱ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 0, 0 });
            Braille['ㄴ'] = ListToBlock(new List<int> { 1, 0, 0, 1, 0, 0 });
            Braille['ㄷ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 0, 0 });
            Braille['ㄹ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 1, 0 });
            Braille['ㅁ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 1, 0 });
            Braille['ㅂ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 1, 0 });
            Braille['ㅅ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1 });
            Braille['ㅇ'] = ListToBlock(new List<int> { 1, 1, 0, 1, 1, 0 });
            Braille['ㅈ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 0, 1 });
            Braille['ㅊ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 1, 1 });
            Braille['ㅋ'] = ListToBlock(new List<int> { 1, 1, 0, 1, 0, 0 });
            Braille['ㅌ'] = ListToBlock(new List<int> { 1, 1, 0, 0, 1, 0 });
            Braille['ㅍ'] = ListToBlock(new List<int> { 1, 0, 0, 1, 1, 0 });
            Braille['ㅎ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 1, 0 });
            Braille['ㄱ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 0, 0 });
            Braille['ㄴ'] = ListToBlock(new List<int> { 1, 0, 0, 1, 0, 0 });
            Braille['ㄷ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 0, 0 });
            Braille['ㄹ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 1, 0 });
            Braille['ㅁ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 1, 0 });
            Braille['ㅂ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 1, 0 });
            Braille['ㅅ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1 });
            Braille['ㅇ'] = ListToBlock(new List<int> { 1, 1, 0, 1, 1, 0 });
            Braille['ㅈ'] = ListToBlock(new List<int> { 0, 0, 0, 1, 0, 1 });
            Braille['ㅊ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 1, 1 });
            Braille['ㅋ'] = ListToBlock(new List<int> { 1, 1, 0, 1, 0, 0 });
            Braille['ㅌ'] = ListToBlock(new List<int> { 1, 1, 0, 0, 1, 0 });
            Braille['ㅍ'] = ListToBlock(new List<int> { 1, 0, 0, 1, 1, 0 });
            Braille['ㅎ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 1, 0 });
            Braille['ㄲ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 });
            Braille['ㄸ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 });
            Braille['ㅃ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0 });
            Braille['ㅆ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 });
            Braille['ㅉ'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 });
            Braille['ㅏ'] = ListToBlock(new List<int> { 1, 1, 0, 0, 0, 1 });
            Braille['ㅑ'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 0 });
            Braille['ㅓ'] = ListToBlock(new List<int> { 0, 1, 1, 1, 0, 0 });
            Braille['ㅕ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 1, 1 });
            Braille['ㅗ'] = ListToBlock(new List<int> { 1, 0, 1, 0, 0, 1 });
            Braille['ㅛ'] = ListToBlock(new List<int> { 0, 0, 1, 1, 0, 1 });
            Braille['ㅜ'] = ListToBlock(new List<int> { 1, 0, 1, 1, 0, 0 });
            Braille['ㅠ'] = ListToBlock(new List<int> { 1, 0, 0, 1, 0, 1 });
            Braille['ㅡ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 0, 1 });
            Braille['ㅣ'] = ListToBlock(new List<int> { 1, 0, 1, 0, 1, 0 });
            Braille['ㅐ'] = ListToBlock(new List<int> { 1, 1, 1, 0, 1, 0 });
            Braille['ㅔ'] = ListToBlock(new List<int> { 1, 0, 1, 1, 1, 0 });
            Braille['ㅒ'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 });
            Braille['ㅖ'] = ListToBlock(new List<int> { 0, 0, 1, 1, 0, 0 });
            Braille['ㅘ'] = ListToBlock(new List<int> { 1, 1, 1, 0, 0, 1 });
            Braille['ㅙ'] = ListToBlock(new List<int> { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0 });
            Braille['ㅚ'] = ListToBlock(new List<int> { 1, 0, 1, 1, 1, 1 });
            Braille['ㅝ'] = ListToBlock(new List<int> { 1, 1, 1, 1, 0, 0 });
            Braille['ㅞ'] = ListToBlock(new List<int> { 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0 });
            Braille['ㅟ'] = ListToBlock(new List<int> { 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0 });
            Braille['ㅢ'] = ListToBlock(new List<int> { 0, 1, 0, 1, 1, 1 });
            Braille['ㄱ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 0, 0 });
            Braille['ㄴ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 0 });
            Braille['ㄷ'] = ListToBlock(new List<int> { 0, 0, 1, 0, 1, 0 });
            Braille['ㄹ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0 });
            Braille['ㅁ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 1 });
            Braille['ㅂ'] = ListToBlock(new List<int> { 1, 1, 0, 0, 0, 0 });
            Braille['ㅅ'] = ListToBlock(new List<int> { 0, 0, 1, 0, 0, 0 });
            Braille['ㅇ'] = ListToBlock(new List<int> { 0, 1, 1, 0, 1, 1 });
            Braille['ㅈ'] = ListToBlock(new List<int> { 1, 0, 1, 0, 0, 0 });
            Braille['ㅊ'] = ListToBlock(new List<int> { 0, 1, 1, 0, 0, 0 });
            Braille['ㅋ'] = ListToBlock(new List<int> { 0, 1, 1, 0, 1, 0 });
            Braille['ㅌ'] = ListToBlock(new List<int> { 0, 1, 1, 0, 0, 1 });
            Braille['ㅍ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 1 });
            Braille['ㅎ'] = ListToBlock(new List<int> { 0, 0, 1, 0, 1, 1 });
            Braille['ㄲ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
            Braille['ㄳ'] = ListToBlock(new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
            Braille['ㄵ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 });
            Braille['ㄶ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1 });
            Braille['ㄺ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
            Braille['ㄻ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 });
            Braille['ㄼ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 });
            Braille['ㄽ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
            Braille['ㄾ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 });
            Braille['ㄿ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1 });
            Braille['ㅀ'] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1 });
            Braille['ㅄ'] = ListToBlock(new List<int> { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
            Braille['ㅆ'] = ListToBlock(new List<int> { 0, 0, 1, 1, 0, 0 });
            Braille['a'] = ListToBlock(new List<int> { 1, 0, 0, 0, 0, 0 });
            Braille['b'] = ListToBlock(new List<int> { 1, 1, 0, 0, 0, 0 });
            Braille['c'] = ListToBlock(new List<int> { 1, 0, 0, 1, 0, 0 });
            Braille['d'] = ListToBlock(new List<int> { 1, 0, 0, 1, 1, 0 });
            Braille['e'] = ListToBlock(new List<int> { 1, 0, 0, 0, 1, 0 });
            Braille['f'] = ListToBlock(new List<int> { 1, 1, 0, 1, 0, 0 });
            Braille['g'] = ListToBlock(new List<int> { 1, 1, 0, 1, 1, 0 });
            Braille['h'] = ListToBlock(new List<int> { 1, 1, 0, 0, 1, 0 });
            Braille['i'] = ListToBlock(new List<int> { 0, 1, 0, 1, 0, 0 });
            Braille['j'] = ListToBlock(new List<int> { 0, 1, 0, 1, 1, 0 });
            Braille['k'] = ListToBlock(new List<int> { 1, 0, 1, 0, 0, 0 });
            Braille['l'] = ListToBlock(new List<int> { 1, 1, 1, 0, 0, 0 });
            Braille['m'] = ListToBlock(new List<int> { 1, 0, 1, 1, 0, 0 });
            Braille['n'] = ListToBlock(new List<int> { 1, 0, 1, 1, 1, 0 });
            Braille['o'] = ListToBlock(new List<int> { 1, 0, 1, 0, 1, 0 });
            Braille['p'] = ListToBlock(new List<int> { 1, 1, 1, 1, 0, 0 });
            Braille['q'] = ListToBlock(new List<int> { 1, 1, 1, 1, 1, 0 });
            Braille['r'] = ListToBlock(new List<int> { 1, 1, 1, 0, 1, 0 });
            Braille['s'] = ListToBlock(new List<int> { 0, 1, 1, 1, 0, 0 });
            Braille['t'] = ListToBlock(new List<int> { 0, 1, 1, 1, 1, 0 });
            Braille['u'] = ListToBlock(new List<int> { 1, 0, 1, 0, 0, 1 });
            Braille['v'] = ListToBlock(new List<int> { 1, 1, 1, 0, 0, 1 });
            Braille['w'] = ListToBlock(new List<int> { 0, 1, 1, 1, 1, 1 });
            Braille['x'] = ListToBlock(new List<int> { 1, 0, 1, 1, 0, 1 });
            Braille['y'] = ListToBlock(new List<int> { 1, 0, 1, 1, 1, 1 });
            Braille['z'] = ListToBlock(new List<int> { 1, 0, 1, 0, 1, 1 });
            Braille['A'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 });
            Braille['B'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 });
            Braille['C'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 });
            Braille['D'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0 });
            Braille['E'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0 });
            Braille['F'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 });
            Braille['G'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0 });
            Braille['H'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0 });
            Braille['I'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 });
            Braille['J'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0 });
            Braille['K'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0 });
            Braille['L'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 });
            Braille['M'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0 });
            Braille['N'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0 });
            Braille['O'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0 });
            Braille['P'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 });
            Braille['Q'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0 });
            Braille['R'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0 });
            Braille['S'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0 });
            Braille['T'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0 });
            Braille['U'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1 });
            Braille['V'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1 });
            Braille['W'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1 });
            Braille['X'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1 });
            Braille['Y'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1 });
            Braille['Z'] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1 });
            Braille['1'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 });
            Braille['2'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 });
            Braille['3'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0 });
            Braille['4'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0 });
            Braille['5'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0 });
            Braille['6'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0 });
            Braille['7'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0 });
            Braille['8'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0 });
            Braille['9'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0 });
            Braille['0'] = ListToBlock(new List<int> { 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0 });

            Braille[' '] = ListToBlock(new List<int> { 0, 0, 0, 0, 0, 0 });

            Braille[','] = ListToBlock(new List<int> { 0, 1, 0, 0, 0, 0 });
            Braille['.'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 1 });
            Braille['-'] = ListToBlock(new List<int> { 0, 1, 0, 0, 1, 0 });
            Braille['?'] = ListToBlock(new List<int> { 0, 1, 1, 0, 0, 1 });
            Braille['_'] = ListToBlock(new List<int> { 0, 0, 1, 0, 0, 1 });
            Braille['!'] = ListToBlock(new List<int> { 0, 1, 1, 0, 1, 0 });
        }
        private List<List<char>> StringToSplit(string str)
        {
            List<List<char>> result = new List<List<char>>();

            foreach (var ch in str)
            {
                result.Add(CharToSplit(ch));
            }

            return result;
        }


        public List<List<Block>> StringToBriall(string str)
        {
            var result = new List<List<Block>>();

            var getSplit = StringToSplit(str);

            foreach (var p in getSplit)
            {
                var munja = new List<Block>();

                foreach (var o in p)
                {
                    if (Braille.ContainsKey(o))
                    {
                        munja.Add(Braille[o]);
                    }
                    else
                    {
                        munja.Add(ListToBlock(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
                    }
                }

                result.Add(munja);
            }

            return result;
        }

        public void Write(string path, List<List<Block>> result)
        {
            using (XmlWriter xml = XmlWriter.Create(path))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("String");

                foreach (var ch in result)
                {
                    xml.WriteStartElement("Word");
                    foreach (var jagan in ch)
                    {
                        xml.WriteStartElement("Jagan");

                        string str = string.Empty;

                        foreach (var j in jagan)
                        {
                            str += j ? "1 " : "0 ";
                        }

                        xml.WriteString(str.Trim());

                        xml.WriteEndElement();
                    }
                    xml.WriteEndElement();
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }

    }
}
