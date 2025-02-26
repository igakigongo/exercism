namespace GradeSchool;

public class GradeSchool
{
    private readonly Dictionary<string, int> _students = [];

    public bool Add(string student, int grade)
    {
        return _students.TryAdd(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        return _students
            .OrderBy(x => x.Value)
            .ThenBy(x => x.Key)
            .Select(x => x.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _students
            .Where(x => x.Value == grade)
            .OrderBy(x => x.Key)
            .Select(x => x.Key);
    }
}