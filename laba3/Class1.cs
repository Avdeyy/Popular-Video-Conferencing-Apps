using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba3
{
    public enum Services
    {
        Discord = 1,
        SberJazz = 2,
        Zoom = 3,
        Skype = 4,
        WebinarSFU = 5
    }
    public class Teacher
    {
        
        public Teacher(string name, string instute, Services service)
        {
            Name = name;
            Institute = instute;
            Program = service;
        }
        public string Name { get; set; }
        public string Institute { get; set; }
        public Services Program { get; set; }

        public List<TopServices> TopService { get; set; } = new List<TopServices>();
        public static List<TopServices> Top(List<Teacher> teachers)
        {
            return new List<TopServices>(teachers.GroupBy(s => s.Program).Select(x => new TopServices(x.Key, x.Count())).OrderByDescending(c => c.Rating).Take(3).ToList());
        }
    }

    public class lT
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }

    public static class MainClass
    {
        public static string Rename(this string n)
        {
            string[] s = n.Split(' ');
            s[1].ToUpper(); s[2].ToUpper();
            n = s[0] + s[1][0] + s[2][0];
            return s[0] + " " + s[1][0] + ". " + s[2][0] + ".";
        }
        public static void newt(this List<Teacher> l, string n, string i, Services p)
        {
            Teacher h = new Teacher(n, i, p);
            h.Name = n; h.Institute = i; h.Program = p;
            l.Add(h);
        }
    }

    public class TopServices
    {
        public TopServices(Services service, int count)
        {
            Program = service;
            Rating = count;
        }
        public Services Program { get; set; }
        public int Rating { get; set; }
    }

    delegate bool IsCanAddTeacher(string name);
}
