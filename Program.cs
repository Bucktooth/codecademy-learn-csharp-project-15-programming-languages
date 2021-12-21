using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

      foreach (var lang in languages)
      {
        //Console.WriteLine(lang.Prettify());
      }

      var basicInfos = languages.Select(x => $"{x.Year}, {x.Name}, {x.ChiefDeveloper}");

      foreach (var lang in basicInfos)
      {
        //Console.WriteLine(lang);
      }

      var cSharpLangs = languages.Where(x => x.Name == "C#");

      foreach (var lang in cSharpLangs)
      {
        //Console.WriteLine(lang.Prettify());
      }

      var microsoftLangs = languages.Where(x => x.ChiefDeveloper.Contains("Microsoft"));

      foreach (var lang in microsoftLangs)
      {
        //Console.WriteLine(lang.Prettify());
      }

      var lispLangs = languages.Where(x => x.Predecessors.Contains("Lisp"));

      foreach (var lang in lispLangs)
      {
        //Console.WriteLine(lang.Prettify());
      }

      var scriptLangs = languages
        .Where(x => x.Name.Contains("Script"))
        .Select(x => x.Name);

      foreach (var lang in scriptLangs)
      {
        //Console.WriteLine(lang);
      }

      //Console.WriteLine($"Number of languages in languages list: {languages.Count()}");

      var langsBetween95And05 = languages
        .Where(x => x.Year >= 1995 && x.Year <= 2005)
        .Select(x => $"{x.Name} was invented in {x.Year}");

      //Console.WriteLine($"Languages launched between 1995 and 2005: {langsBetween95And05.Count()}");
      foreach (var lang in langsBetween95And05)
      {
        //Console.WriteLine(lang);
      }

      //PrettyPrintAll(lispLangs);
      //PrintAll(langsBetween95And05);

      var alphabeticalOrder = languages.OrderBy(x => x.Name);
      //PrettyPrintAll(alphabeticalOrder);

      var oldestLanguage = languages.Min(x => x.Year);
      Console.WriteLine(oldestLanguage);

      var oldestLanguageName = languages
        .Where(x => x.Year == oldestLanguage)
        .Select(x => x.Name);
      Console.WriteLine($"The oldest language is {oldestLanguageName} and was created in {oldestLanguage}.");
    }

    public static void PrettyPrintAll(IEnumerable<Language> langs)
    {
      foreach (Language lang in langs)
      {
        Console.WriteLine(lang.Prettify());
      }
    }

    public static void PrintAll(IEnumerable<Object> sequence)
    {
      foreach (Object obj in sequence)
      {
        Console.WriteLine(obj);
      }
    }
  }
}
