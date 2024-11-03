namespace Day_19;

public class Workflow
{
    public string Name { get; private set; }
    private readonly List<Func<MachinePart, (bool, string)>> _rules = new();

    public Workflow(string name, string rulesString)
    {
        Name = name;
        SetupRules(rulesString);
    }

    private void SetupRules(string rulesString)
    {
        string[] rules = rulesString.Split(',');

        foreach (string rule in rules)
        {
            if (!rule.Contains('>') && !rule.Contains('<'))
            {
                _rules.Add(machinePart => (true, rule));
                continue;
            }

            char category = rule[0];

            if (category == 'x')
            {
                if (rule.Contains('>'))
                {
                    string numString = rule[(rule.IndexOf('>') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.XVal > num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
                else
                {
                    string numString = rule[(rule.IndexOf('<') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.XVal < num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
            }
            else if (category == 'm')
            {
                if (rule.Contains('>'))
                {
                    string numString = rule[(rule.IndexOf('>') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.MVal > num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
                else
                {
                    string numString = rule[(rule.IndexOf('<') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.MVal < num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
            }
            else if (category == 'a')
            {
                if (rule.Contains('>'))
                {
                    string numString = rule[(rule.IndexOf('>') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.AVal > num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
                else
                {
                    string numString = rule[(rule.IndexOf('<') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.AVal < num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
            }
            else
            {
                if (rule.Contains('>'))
                {
                    string numString = rule[(rule.IndexOf('>') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.SVal > num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
                else
                {
                    string numString = rule[(rule.IndexOf('<') + 1)..rule.IndexOf(':')];
                    int num = int.Parse(numString);
                    _rules.Add(machinePart =>
                    {
                        if (machinePart.SVal < num)
                        {
                            return (true, rule[(rule.IndexOf(':') + 1)..]);
                        }

                        return (false, "FALSE");
                    });
                }
            }
        }
    }

    public string CheckMachinePart(MachinePart machinePart)
    {
        foreach (Func<MachinePart, (bool, string)> rule in _rules)
        {
            (bool, string) result = rule(machinePart);

            if (result.Item1)
            {
                return result.Item2;
            }
        }

        throw new Exception("None of the rules returned true");
    }
}