using System;
using System.Collections.Generic;
using System.Linq;

class ClubElections
{
    // ── Club Member Data ─────────────────────────────────────
    // Each member has: id, name, grade, favoriteColor
    static List<Dictionary<string, object>> members = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object> { {"id", 1}, {"name", "Alice"},  {"grade", 10}, {"favoriteColor", "red"} },
        new Dictionary<string, object> { {"id", 2}, {"name", "Beth"},   {"grade", 11}, {"favoriteColor", "blue"} },
        new Dictionary<string, object> { {"id", 3}, {"name", "Carlos"}, {"grade", 10}, {"favoriteColor", "green"} },
        new Dictionary<string, object> { {"id", 4}, {"name", "Dana"},   {"grade", 12}, {"favoriteColor", "blue"} },
        new Dictionary<string, object> { {"id", 5}, {"name", "Eli"},    {"grade", 11}, {"favoriteColor", null} },
        new Dictionary<string, object> { {"id", 6}, {"name", "Fay"},    {"grade", 10}, {"favoriteColor", "red"} },
        new Dictionary<string, object> { {"id", 7}, {"name", "Grace"},  {"grade", 12}, {"favoriteColor", "purple"} },
        new Dictionary<string, object> { {"id", 8}, {"name", "Hank"},   {"grade", 11}, {"favoriteColor", null} },
    };

    static void NewMember()
    {
        members.Add(new Dictionary<string, object>
        {
            {"id", 9},
            {"name", "Isabel"},
            {"grade", 8},
            {"favoriteColor", "purple"}
        });

        foreach (var member in members)
        {
            Console.WriteLine(member["name"]);
        }
    }



    // ── Votes ───────────────────────────────────────────────
    // Key = voter name, Value = candidate name they voted for
    static Dictionary<string, string> votes = new Dictionary<string, string>
    {
        {"Alice", "Beth"},
        {"Beth", "Beth"},
        {"Carlos", "Dana"},
        {"Dana", "Dana"},
        {"Eli", "Beth"},
        {"Fay", "Grace"},
        // Grace and Hank did not vote
    };

    static void NewVote()
    {
        // Record Isabel's vote
        votes["Isabel"] = "Beth";

        // Print all votes
        foreach (var vote in votes)
        {
            Console.WriteLine($"{vote.Key} voted for {vote.Value}");
        }
    }

static void ChangeVote()
    {
        // Change Isabel's vote
        votes["Isabel"] = "Dana";

        // Print all votes
        foreach (var vote in votes)
        {
            Console.WriteLine($"{vote.Key} voted for {vote.Value}");
        }
    }

    static void NoVote()
    {
        // Remove Isabel's vote
        votes.Remove("Isabel");

        // Print remaining votes
        foreach (var vote in votes)
        {
            Console.WriteLine($"{vote.Key} voted for {vote.Value}");
        }
    }

    // ── Helper Methods (YOU COMPLETE THESE) ─────────────────

    /// <summary>Return the name of the member with the given id, or "Unknown" if not found.</summary>
    static string GetMemberName(int id)
    {
        // TODO: implement this
        foreach (var member in members)
        {
        if ((int)member["id"] == id)
            {
            return member["name"]?.ToString() ?? "Unknown";
            }
        }
        return "Unknown";
    }

    /// <summary>Return the favorite color of the named member, or "N/A" if not found or null.</summary>
    static string GetMemberFavoriteColor(string name)
    {
        // TODO: implement this
        foreach (var member in members)
        {
            if (member["name"].ToString() == name)
            {
                if (member["favoriteColor"] != null)
                {
                    return member["favoriteColor"].ToString();
                }
                return "N/A";
            }
        }
        return "N/A";
    }

    /// <summary>Return who the named member voted for, or "Did not vote" if no record.</summary>
    static string GetVote(string voterName)
    {
        // TODO: implement this
        if (votes.ContainsKey(voterName))
        {
            return votes[voterName];
        }
        return "Did not vote";
    }

    static void MembersWithBlueFavoriteColor()
    {
        foreach (var member in members)
        {
            if (member["favoriteColor"] != null &&
                member["favoriteColor"].ToString() == "blue")
            {
                Console.WriteLine(member["name"]);
            }
        }
    }

static void MembersWithNoFavoriteColor()
    {
        foreach (var member in members)
        {
            if (member["favoriteColor"] == null)
            {
                Console.WriteLine(member["name"]);  
            }
        }
    }

    static int CountTenthGraders()
    {
        int count = 0;

        foreach (var member in members)
        {
            if ((int)member["grade"] == 10)
            {
                count++;
            }
        }

        return count;
    }

    static void VotesForBeth()
    {
        foreach (var vote in votes)
        {
            if (vote.Value == "Beth")
            {
                Console.WriteLine(vote.Key);
            }
        }
    }

    static void SelfVote()
    {
        foreach (var vote in votes)
        {
            if (vote.Key == vote.Value)
            {
                Console.WriteLine(vote.Key);
            }
        }
    }

    static void WhoDidNotVote()
    {
        foreach (var member in members)
        {
            string name = member["name"].ToString();

            if (!votes.ContainsKey(name))
            {
                Console.WriteLine(name);
            }
        }
    }

    static void ElectionResults()
    {
        Dictionary<string, int> results = new Dictionary<string, int>();

        foreach (var vote in votes.Values)
        {
            if (results.ContainsKey(vote))
            {
                results[vote]++;
            }
            else
            {
                results[vote] = 1;
            }
        }

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Key}: {result.Value}");
        }
    }

    // ── Main ────────────────────────────────────────────────
    static void Main()
    {
        Console.WriteLine("=== Club Elections ===" );
        Console.WriteLine("---- Member Question Answers (1-7) ----" );
        Console.WriteLine(GetMemberName(5));
        Console.WriteLine("----" );
        Console.WriteLine(GetMemberFavoriteColor("Eli"));
        Console.WriteLine("----" );
        MembersWithBlueFavoriteColor();
        Console.WriteLine("----" );
        MembersWithNoFavoriteColor();
        Console.WriteLine("----" );
        Console.WriteLine(members.Count);
        Console.WriteLine("----" );
        Console.WriteLine(CountTenthGraders());
        Console.WriteLine("---- Member Question Answers (8-13) ----" );
        Console.WriteLine(GetVote("Fay"));
        Console.WriteLine("----" );
        Console.WriteLine(GetVote("Beth"));
        Console.WriteLine("----" );
        VotesForBeth();
        Console.WriteLine("----" );
        SelfVote();
        Console.WriteLine("----" );
        WhoDidNotVote();
        Console.WriteLine("----" );
        ElectionResults();
        Console.WriteLine("Winner is Beth" );
        Console.WriteLine("---- Member Question Answers (14-17) ----" );
        NewMember();
        Console.WriteLine("----" );
        NewVote();
        Console.WriteLine("----" );
        ChangeVote();
        Console.WriteLine("----" );
        NoVote();

        // ---- Member Questions (1-7) ----
        // 1. Who is member #5?
        // 2. What is member #5's favorite color?
        // 3. Whose favorite color is blue? (print all)
        // 4. Who doesn't have a favorite color? (print all)
        // 5. How many members are there?
        // 6. How many members are in 10th grade?

        // ---- Voting Questions (8-13) ----
        // 7. Who did member #6 vote for?
        // 8. Who did Beth vote for?
        // 9. Who voted for Beth? (print all)
        // 10. Who voted for themselves?
        // 11. Who didn't vote? (print all)
        // 12. Print the election results (candidate: vote count)
        // 13. Who won the election?

        // ---- Operations (14-17) ----
        // 14. Add a member: Isabel, id 9, grade 8, favorite color purple
        // 15. Record that Isabel voted for Beth
        // 16. Change Isabel's vote to Dana
        // 17. Remove Isabel's vote
    }
}
