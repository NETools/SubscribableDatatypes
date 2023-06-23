// - 1 -
using SubscribableDatatypes;
using System.Diagnostics;

Test test = new Test();

test.IntegerVariable.ValueChanged += IntegerVariable_ValueChanged;
test.IntegerVariable.Value = 5;

void IntegerVariable_ValueChanged(int oldValue)
{
	Console.WriteLine($"Value of {nameof(test.IntegerVariable)} has changed from {oldValue} to {test.IntegerVariable.Value}.");
}

class Test
{
	public NSVariable<int> IntegerVariable { get; set; } = 15;
}