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
    static List<string> phraseInts = new List<string>(){"мянга", "сая", "тэрбум", "их наяд"};

    static string hundredStr = "зуун";
    
    static string CurrencyUnitStr = "төгрөг";
    
    static string phraselCurrency(long currency) {
        if(currency >= 1000000000000000)
            return "999 их наядаас их тоо байна!"
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
                return "нэг";
            if(unit == 2)
                return "хоёр";
            if(unit == 3)
                return "гурван";
            if(unit == 4)
                return "дөрвөн";
            if(unit == 5)
                 return "таван";
            if(unit == 6)
                return "зургаан";
            if(unit == 7)
                return "долоон";
            if(unit == 8)
                return "найман";
            if(unit == 9)
                return "есөн";
            return "";
    }
     static string twoUnitSwitch(int unit) {
            if(unit == 10)
                return "арван";
            if(unit == 20)
                return "хорин";
            if(unit == 30)
                return "гучин";
            if(unit == 40)
                return "дөчин";
            if(unit == 50)
                 return "тавин";
            if(unit == 60)
                return "жаран";
            if(unit == 70)
                return "далан";
            if(unit == 80)
                return "наяан";
            if(unit == 90)
                return "ерэн";
        return "";
    }
}
