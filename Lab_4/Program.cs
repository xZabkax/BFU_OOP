using Lab_4;

var observableForDataChanged = new ObservableForDataChanged();
var observableForDataChanging = new User(); 

var consoleChangedLogger = new ConsoleChangeLogger();
var nameValidator = new NameValidator();
var ageValidator = new AgeValidator();

observableForDataChanged.AddPropertyChangedListeners(consoleChangedLogger);
observableForDataChanging.AddPropertyChangingListeners(nameValidator, ageValidator);

observableForDataChanged.Attribute1 = "Test";
observableForDataChanged.Attribute2 = 3;

observableForDataChanging.Name = "Иван";
observableForDataChanging.Age = -45;
observableForDataChanging.Name = "";

observableForDataChanged.RemovePropertyChangedListeners(consoleChangedLogger);

observableForDataChanged.Attribute1 = "1";



