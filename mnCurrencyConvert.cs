using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine(phraselCurrency(324234));
    }
    
    static List<long> dividerInts = new List<long>(){1000, 1000000, 1000000000, 1000000000000};//ih nayd hurtel uldegdeltei huvaagchid
    static List<string> phraseInts = new List<string>(){"Мянга", "Сая", "Тэрбум", "Их наяд"};

    static string hundredStr = "Зуун";
    
    static string CurrencyUnitStr = "Төгрөг";
    
    static string phraselCurrency(long currency) {
        //divider ints hoinoos ni davtana
        //ehnii gurvan orong avna
        //uldegdeltei huvaagaad hargalzah phraseInt iig zalgaj ehnii gurvan orong ustgana
        //hasOneUnit, hasTwoUnit uyd switchees utgiig avna
        string phrase = "";
        long remainingHundred = currency%1000;
        for(int i=dividerInts.Count-1; i>=0; i--) {
            int leadingNum = unchecked((int)(currency/dividerInts[i]));
            if(leadingNum>0) {
                phrase+=threeUnitPhrase(leadingNum);
                phrase+=" "+phraseInts[i];
                long remainder = currency%dividerInts[i];
                if(dividerInts[i]==1000 && remainder==0)
                    phrase+="н";
                phrase+=" ";
                currency = remainder;
            }
        }
        phrase+=" "+threeUnitPhrase((int)remainingHundred);
        return phrase+" "+CurrencyUnitStr;
    }
    
    static string threeUnitPhrase(int leadingNum) {
        int totalHundred = leadingNum /100;
        string totalHundredStr = oneUnitSwitch(totalHundred);
        if(totalHundredStr.Length>0)
            totalHundredStr += " "+hundredStr;
        leadingNum%=100;
        int oneUnitRemainder = leadingNum%10;
        string oneUnitRemainderStr = oneUnitSwitch(oneUnitRemainder);
        int twoUnit = leadingNum-oneUnitRemainder;
        string twoUnitStr = twoUnitSwitch(twoUnit);
        
        string threeUnitStr = "";
        if(totalHundredStr.Length>0)
            threeUnitStr+=totalHundredStr+" ";
            
        if(twoUnitStr.Length>0)
            threeUnitStr+=twoUnitStr+" ";
            
        if(oneUnitRemainderStr.Length>0)
            threeUnitStr+=oneUnitRemainderStr;
            
        return threeUnitStr;
    }


    static string oneUnitSwitch(int unit) {
            if(unit == 1)
                return "Нэг";
            if(unit == 2)
                return "Хоёр";
            if(unit == 3)
                return "Гурван";
            if(unit == 4)
                return "Дөрвөн";
            if(unit == 5)
                 return "Таван";
            if(unit == 6)
                return "Зургаан";
            if(unit == 7)
                return "Долоон";
            if(unit == 8)
                return "Найман";
            if(unit == 9)
                return "Есөн";
            return "";
    }
     static string twoUnitSwitch(int unit) {
            if(unit == 10)
                return "Арван";
            if(unit == 20)
                return "Хорин";
            if(unit == 30)
                return "Гучин";
            if(unit == 40)
                return "Дөчин";
            if(unit == 50)
                 return "Тавин";
            if(unit == 60)
                return "Жаран";
            if(unit == 70)
                return "Далан";
            if(unit == 80)
                return "Наяан";
            if(unit == 90)
                return "Ерэн";
        return "";
    }
}
