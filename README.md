# ConfusedExercise
This code is a solution to the Confused.com test engineer exercise.  It has been implemented using the following technologies:
  1. Visual Studio 2017
  2. .net framework 4.8
  3. c# 8.0
  4. Specflow
  5. Selenium Webdriver
  6. MSTest
  7. Fluent Assertions
  8. Chrome
 
 The solution contains a number of tests written in the 'Gherkin' style of notation and, when executed, will open a chrome browser, navigate to the https://computer-database.herokuapp.com/computers example website and perform some key actions such as; adding, deleted and filtering on data.  The use of Gherkin here is to allow the tests to be written in an easily readable and relatable way.  The intention is that all stakeholders involved with delivering the software have a shared understanding of the expected behaviours of the system.  This also allows the tests to document the system behaves and is sometimes referred to as 'living documentation'.
 
 The code has been implemented using the Page Objects Model.  This pattern separates out the concerns of interacting with the user interface from the tests.  This allows the tests to express the intent of what is to be achieved, defering the 'how' to the page objects.  The page objects encapsulate the detail of interacting with web pages using Selenium Webdriver which has been used to simulate a human user opening and using the browser.  The Page Objects Model is currently seen as the go-to pattern for UI tests to enable code creation that does not repeat itself (DRY), enables separation of concerns and produces test code that is ultimately more maintainable and extensible. 
 
 Test assertions (i.e. determining whether the test passed or failed) are achieved using Fluent Assertions.  This allows for a descriptive, readable assertions to be made on the application under test.
 
 The tests leverage the Dependency Injection capability of Specflow to instantiate and also manage the lifetime of test dependencies.  Specifically, the tests rely upon a 'BrowserActor' object - this is instantiated by a BeforeScenario hook and registered in Specflow's Feature DI container.  The 'BrowserActor' is a wrapper around Selenium Webdriver and contains methods to instantiate page objects.  The DI container's contents exist for the duration of the feature and are automatically disposed of when the test feature finishes.  Specflow is also able to inject dependencies into test steps files (Context Injection) so by requiring the BrowserActor as one of the constructor parameters in the test steps, the dependency is injected automatically at runtime.  Injecting dependencies in this way has the advantage of making the tests thread safe and so the tests could be executed in parallel, if required.
