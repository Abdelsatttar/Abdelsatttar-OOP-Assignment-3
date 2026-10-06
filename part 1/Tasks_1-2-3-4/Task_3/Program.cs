using RefactoringLab.Part02.Enrollment;

Console.WriteLine("=== Enrollment ===");
var studentId = "S100";
var courseId = "CS201";
var amount = 1500m;

var enrollment = new EnrollmentFacade();
enrollment.Enroll(studentId, courseId, amount);
