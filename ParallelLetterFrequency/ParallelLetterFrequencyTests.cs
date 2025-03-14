using Xunit;

namespace ParallelLetterFrequency;

public class ParallelLetterFrequencyTests
{
    [Fact]
    public void No_texts()
    {
        string[] texts = [];
        var expected = new Dictionary<char, int>();
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void One_text_with_one_letter()
    {
        string[] texts =
        [
            "a"
        ];
        var expected = new Dictionary<char, int>
        {
            ['a'] = 1
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void One_text_with_multiple_letters()
    {
        string[] texts =
        [
            "bbcccd"
        ];
        var expected = new Dictionary<char, int>
        {
            ['b'] = 2,
            ['c'] = 3,
            ['d'] = 1
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Two_texts_with_one_letter()
    {
        string[] texts =
        [
            "e",
            "f"
        ];
        var expected = new Dictionary<char, int>
        {
            ['e'] = 1,
            ['f'] = 1
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Two_texts_with_multiple_letters()
    {
        string[] texts =
        [
            "ggh",
            "hhi"
        ];
        var expected = new Dictionary<char, int>
        {
            ['g'] = 2,
            ['h'] = 3,
            ['i'] = 1
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Ignore_letter_casing()
    {
        string[] texts =
        [
            "m",
            "M"
        ];
        var expected = new Dictionary<char, int>
        {
            ['m'] = 2
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Ignore_whitespace()
    {
        string[] texts =
        [
            "   ",
            "\t",
            "\r\n"
        ];
        var expected = new Dictionary<char, int>();
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Ignore_punctuation()
    {
        string[] texts =
        [
            "!",
            "?",
            ";",
            ",",
            "."
        ];
        var expected = new Dictionary<char, int>();
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Ignore_numbers()
    {
        string[] texts =
        [
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        ];
        var expected = new Dictionary<char, int>();
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Unicode_letters()
    {
        string[] texts =
        [
            "本",
            "φ",
            "ほ",
            "ø"
        ];
        var expected = new Dictionary<char, int>
        {
            ['本'] = 1,
            ['φ'] = 1,
            ['ほ'] = 1,
            ['ø'] = 1
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Combination_of_lower_and_uppercase_letters_punctuation_and_white_space()
    {
        string[] texts =
        [
            "There, peeping among the cloud-wrack above a dark tower high up in the mountains, Sam saw a white star twinkle for a while. The beauty of it smote his heart, as he looked up out of the forsaken land, and hope returned to him. For like a shaft, clear and cold, the thought pierced him that in the end, the shadow was only a small and passing thing: there was light and high beauty forever beyond its reach."
        ];
        var expected = new Dictionary<char, int>
        {
            ['a'] = 32,
            ['b'] = 4,
            ['c'] = 6,
            ['d'] = 14,
            ['e'] = 37,
            ['f'] = 7,
            ['g'] = 8,
            ['h'] = 29,
            ['i'] = 19,
            ['k'] = 6,
            ['l'] = 12,
            ['m'] = 7,
            ['n'] = 19,
            ['o'] = 22,
            ['p'] = 7,
            ['r'] = 17,
            ['s'] = 16,
            ['t'] = 30,
            ['u'] = 9,
            ['v'] = 2,
            ['w'] = 9,
            ['y'] = 4
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Large_texts()
    {
        string[] texts =
        [
            "I am a sick man.... I am a spiteful man. I am an unattractive man.\nI believe my liver is diseased. However, I know nothing at all about my disease, and do not\nknow for certain what ails me. I don't consult a doctor for it,\nand never have, though I have a respect for medicine and doctors.\nBesides, I am extremely superstitious, sufficiently so to respect medicine,\nanyway (I am well-educated enough not to be superstitious, but I am superstitious).\nNo, I refuse to consult a doctor from spite.\nThat you probably will not understand. Well, I understand it, though.\nOf course, I can't explain who it is precisely that I am mortifying in this case by my spite:\nI am perfectly well aware that I cannot \"pay out\" the doctors by not consulting them;\nI know better than anyone that by all this I am only injuring myself and no one else.\nBut still, if I don't consult a doctor it is from spite.\nMy liver is bad, well - let it get worse!\nI have been going on like that for a long time - twenty years. Now I am forty.\nI used to be in the government service, but am no longer.\nI was a spiteful official. I was rude and took pleasure in being so.\nI did not take bribes, you see, so I was bound to find a recompense in that, at least.\n(A poor jest, but I will not scratch it out. I wrote it thinking it would sound very witty;\nbut now that I have seen myself that I only wanted to show off in a despicable way -\nI will not scratch it out on purpose!) When petitioners used to come for\ninformation to the table at which I sat, I used to grind my teeth at them,\nand felt intense enjoyment when I succeeded in making anybody unhappy.\nI almost did succeed. For the most part they were all timid people - of course,\nthey were petitioners. But of the uppish ones there was one officer in particular\nI could not endure. He simply would not be humble, and clanked his sword in a disgusting way.\nI carried on a feud with him for eighteen months over that sword. At last I got the better of him.\nHe left off clanking it. That happened in my youth, though. But do you know,\ngentlemen, what was the chief point about my spite? Why, the whole point,\nthe real sting of it lay in the fact that continually, even in the moment of the acutest spleen,\nI was inwardly conscious with shame that I was not only not a spiteful but not even an embittered man,\nthat I was simply scaring sparrows at random and amusing myself by it.\nI might foam at the mouth, but bring me a doll to play with, give me a cup of tea with sugar in it,\nand maybe I should be appeased. I might even be genuinely touched,\nthough probably I should grind my teeth at myself afterwards and lie awake at night with shame for\nmonths after. That was my way. I was lying when I said just now that I was a spiteful official.\nI was lying from spite. I was simply amusing myself with the petitioners and with the officer,\nand in reality I never could become spiteful. I was conscious every moment in myself of many,\nvery many elements absolutely opposite to that. I felt them positively swarming in me,\nthese opposite elements. I knew that they had been swarming in me all my life and craving some outlet from me,\nbut I would not let them, would not let them, purposely would not let them come out.\nThey tormented me till I was ashamed: they drove me to convulsions and - sickened me, at last,\nhow they sickened me!",
            "Gentlemen, I am joking, and I know myself that my jokes are not brilliant\n,but you know one can take everything as a joke. I am, perhaps, jesting against the grain.\nGentlemen, I am tormented by questions; answer them for me. You, for instance, want to cure men of their\nold habits and reform their will in accordance with science and good sense.\nBut how do you know, not only that it is possible, but also that it is\ndesirable to reform man in that way? And what leads you to the conclusion that man's\ninclinations need reforming? In short, how do you know that such a reformation will be a benefit to man?\nAnd to go to the root of the matter, why are you so positively convinced that not to act against\nhis real normal interests guaranteed by the conclusions of reason and arithmetic is certainly always\nadvantageous for man and must always be a law for mankind? So far, you know,\nthis is only your supposition. It may be the law of logic, but not the law of humanity.\nYou think, gentlemen, perhaps that I am mad? Allow me to defend myself. I agree that man\nis pre-eminently a creative animal, predestined to strive consciously for an object and to engage in engineering -\nthat is, incessantly and eternally to make new roads, wherever\nthey may lead. But the reason why he wants sometimes to go off at a tangent may just be that he is\npredestined to make the road, and perhaps, too, that however stupid the \"direct\"\npractical man may be, the thought sometimes will occur to him that the road almost always does lead\nsomewhere, and that the destination it leads to is less important than the process\nof making it, and that the chief thing is to save the well-conducted child from despising engineering,\nand so giving way to the fatal idleness, which, as we all know,\nis the mother of all the vices. Man likes to make roads and to create, that is a fact beyond dispute.\nBut why has he such a passionate love for destruction and chaos also?\nTell me that! But on that point I want to say a couple of words myself. May it not be that he loves\nchaos and destruction (there can be no disputing that he does sometimes love it)\nbecause he is instinctively afraid of attaining his object and completing the edifice he is constructing?\nWho knows, perhaps he only loves that edifice from a distance, and is by no means\nin love with it at close quarters; perhaps he only loves building it and does not want to live in it,\nbut will leave it, when completed, for the use of les animaux domestiques -\nsuch as the ants, the sheep, and so on. Now the ants have quite a different taste.\nThey have a marvellous edifice of that pattern which endures for ever - the ant-heap.\nWith the ant-heap the respectable race of ants began and with the ant-heap they will probably end,\nwhich does the greatest credit to their perseverance and good sense. But man is a frivolous and\nincongruous creature, and perhaps, like a chess player, loves the process of the game, not the end of it.\nAnd who knows (there is no saying with certainty), perhaps the only goal on earth\nto which mankind is striving lies in this incessant process of attaining, in other words,\nin life itself, and not in the thing to be attained, which must always be expressed as a formula,\nas positive as twice two makes four, and such positiveness is not life, gentlemen,\nbut is the beginning of death.",
            "But these are all golden dreams. Oh, tell me, who was it first announced,\nwho was it first proclaimed, that man only does nasty things because he does not know his own interests;\nand that if he were enlightened, if his eyes were opened to his real normal interests,\nman would at once cease to do nasty things, would at once become good and noble because,\nbeing enlightened and understanding his real advantage, he would see his own advantage in the\ngood and nothing else, and we all know that not one man can, consciously, act against his own interests,\nconsequently, so to say, through necessity, he would begin doing good? Oh, the babe! Oh, the pure,\ninnocent child! Why, in the first place, when in all these thousands of years has there been a time\nwhen man has acted only from his own interest? What is to be done with the millions of facts that bear\nwitness that men, consciously, that is fully understanding their real interests, have left them in the\nbackground and have rushed headlong on another path, to meet peril and danger,\ncompelled to this course by nobody and by nothing, but, as it were, simply disliking the beaten track,\nand have obstinately, wilfully, struck out another difficult, absurd way, seeking it almost in the darkness.\nSo, I suppose, this obstinacy and perversity were pleasanter to them than any advantage....\nAdvantage! What is advantage? And will you take it upon yourself to define with perfect accuracy in what the\nadvantage of man consists? And what if it so happens that a man's advantage, sometimes, not only may,\nbut even must,  consist in his desiring in certain cases what is harmful to himself and not advantageous.\nAnd if so, if there can be such a case, the whole principle falls into dust. What do you think -\nare there such cases? You laugh; laugh away, gentlemen, but only answer me: have man's advantages been\nreckoned up with perfect certainty? Are there not some which not only have not been included but cannot\npossibly be included under any classification? You see, you gentlemen have, to the best of my knowledge,\ntaken your whole register of human advantages from the averages of statistical figures and\npolitico-economical formulas. Your advantages are prosperity, wealth, freedom, peace - and so on, and so on.\nSo that the man who should, for instance, go openly and knowingly in opposition to all that list would to your thinking,\nand indeed mine, too, of course, be an obscurantist or an absolute madman: would not he? But, you know, this is\nwhat is surprising: why does it so happen that all these statisticians,  sages and lovers of humanity,\nwhen they reckon up human advantages invariably leave out one? They don't even take it into their reckoning\nin the form in which it should be taken, and the whole reckoning depends upon that. It would be no greater matter,\nthey would simply have to take it, this advantage, and add it to the list. But the trouble is, that this strange\nadvantage does not fall under any classification and is not in place in any list. I have a friend for instance ...\nEch! gentlemen, but of course he is your friend, too; and indeed there is no one, no one to whom he is not a friend!",
            "Yes, but here I come to a stop! Gentlemen, you must excuse me for being over-philosophical;\nit's the result of forty years underground! Allow me to indulge my fancy. You see, gentlemen, reason is an excellent thing,\nthere's no disputing that, but reason is nothing but reason and satisfies only the rational side of man's nature,\nwhile will is a manifestation of the whole life, that is, of the whole human life including reason and all the impulses.\nAnd although our life, in this manifestation of it, is often worthless, yet it is life and not simply extracting square roots.\nHere I, for instance, quite naturally want to live, in order to satisfy all my capacities for life, and not simply my capacity\nfor reasoning, that is, not simply one twentieth of my capacity for life. What does reason know? Reason only knows what it has\nsucceeded in learning (some things, perhaps, it will never learn; this is a poor comfort, but why not say so frankly?)\nand human nature acts as a whole, with everything that is in it, consciously or unconsciously, and, even it if goes wrong, it lives.\nI suspect, gentlemen, that you are looking at me with compassion; you tell me again that an enlightened and developed man,\nsuch, in short, as the future man will be, cannot consciously desire anything disadvantageous to himself, that that can be proved mathematically.\nI thoroughly agree, it can - by mathematics. But I repeat for the hundredth time, there is one case, one only, when man may consciously, purposely,\ndesire what is injurious to himself, what is stupid, very stupid - simply in order to have the right to desire for himself even what is very stupid\nand not to be bound by an obligation to desire only what is sensible. Of course, this very stupid thing, this caprice of ours, may be in reality,\ngentlemen, more advantageous for us than anything else on earth, especially in certain cases. And in particular it may be more advantageous than\nany advantage even when it does us obvious harm, and contradicts the soundest conclusions of our reason concerning our advantage -\nfor in any circumstances it preserves for us what is most precious and most important - that is, our personality, our individuality.\nSome, you see, maintain that this really is the most precious thing for mankind; choice can, of course, if it chooses, be in agreement\nwith reason; and especially if this be not abused but kept within bounds. It is profitable and some- times even praiseworthy.\nBut very often, and even most often, choice is utterly and stubbornly opposed to reason ... and ... and ... do you know that that,\ntoo, is profitable, sometimes even praiseworthy? Gentlemen, let us suppose that man is not stupid. (Indeed one cannot refuse to suppose that,\nif only from the one consideration, that, if man is stupid, then who is wise?) But if he is not stupid, he is monstrously ungrateful!\nPhenomenally ungrateful. In fact, I believe that the best definition of man is the ungrateful biped. But that is not all, that is not his worst defect;\nhis worst defect is his perpetual moral obliquity, perpetual - from the days of the Flood to the Schleswig-Holstein period."
        ];
        var expected = new Dictionary<char, int>
        {
            ['a'] = 845,
            ['b'] = 155,
            ['c'] = 278,
            ['d'] = 359,
            ['e'] = 1143,
            ['f'] = 222,
            ['g'] = 187,
            ['h'] = 507,
            ['i'] = 791,
            ['j'] = 12,
            ['k'] = 67,
            ['l'] = 423,
            ['m'] = 288,
            ['n'] = 833,
            ['o'] = 791,
            ['p'] = 197,
            ['q'] = 8,
            ['r'] = 432,
            ['s'] = 700,
            ['t'] = 1043,
            ['u'] = 325,
            ['v'] = 111,
            ['w'] = 223,
            ['x'] = 7,
            ['y'] = 251
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }

    [Fact]
    public void Many_small_texts()
    {
        string[] texts =
        [
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc"
        ];
        var expected = new Dictionary<char, int>
        {
            ['a'] = 50,
            ['b'] = 100,
            ['c'] = 150
        };
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts));
    }
}