# Task Management Application

## ✅ Technical Test - Complete Solution

A full-stack Task Management application built with **Clean Architecture**, **CQRS pattern**, **REST API**, and **modern responsive UI**.

---

## 🏗️ Architecture Overview

### **Clean Architecture Layers:**
```
├── Domain Layer (TaskManagementApp.Domain)
│   ├── Entities (TaskItem)
│   └── Base Classes (BaseEntity)
│
├── Application Layer (TaskManagementApp.Application)
│   ├── Commands (CreateTask, DeleteTask, ToggleTaskCompletion)
│   ├── Queries (GetTasks)
│   ├── DTOs (TaskDto, CreateTaskDto)
│   ├── Interfaces (ITaskRepository, IApplicationDbContext)
│   └── Validators (FluentValidation)
│
├── Infrastructure Layer (TaskManagementApp.Infrastructure)
│   ├── Persistence (ApplicationDbContext, EF Core InMemory)
│   ├── Repositories (TaskRepository)
│   ├── Mapping (AutoMapper)
│   └── Data Seeding (8 sample tasks)
│
└── Presentation Layer (TaskManagementApp.Web)
    ├── REST API Controllers (TasksController)
    ├── Static HTML/JavaScript UI
    └── Modern CSS with gradients
```

---

## 🚀 How to Run

### **Prerequisites:**
- .NET 9.0 SDK installed
- Terminal/Command Prompt access

### **Step 1: Navigate to Project Directory**
```bash
cd "/Users/aifanzenterprise/Desktop/AIFANZ ENTERPRISE/Test"
```

### **Step 2: Build the Solution**
```bash
dotnet build
```

### **Step 3: Run the Application**
```bash
cd src/TaskManagementApp.Web
dotnet run --urls="http://localhost:5000"
```

### **Step 4: Open in Browser**
Open your browser and navigate to:
```
http://localhost:5000
```

---

## 🎯 Features Implemented

### ✅ **Core Requirements:**
- [x] View a list of tasks with 8 pre-seeded sample tasks
- [x] Add a new task with title and description
- [x] Mark a task as completed/pending
- [x] Delete a task with confirmation
- [x] Filter tasks (All, Completed, Pending)

### ✅ **Architecture Requirements:**
- [x] Clean Architecture (4 separate layers)
- [x] CQRS Pattern (Commands and Queries separated)
- [x] MediatR for request/response handling
- [x] Repository Pattern
- [x] Dependency Injection throughout
- [x] Entity Framework Core with InMemory database
- [x] AutoMapper for object mapping

### ✅ **Bonus Points:**
- [x] FluentValidation for input validation
- [x] Modern responsive UI with gradients and animations
- [x] Error handling with Result pattern
- [x] Async/await with CancellationToken support
- [x] REST API with proper HTTP methods
- [x] CORS configuration

---

## 📁 Project Structure

```
Test/
├── TaskManagementApp.sln
└── src/
    ├── TaskManagementApp.Domain/
    │   ├── Entities/
    │   │   └── TaskItem.cs
    │   └── Common/
    │       └── BaseEntity.cs
    │
    ├── TaskManagementApp.Application/
    │   ├── Tasks/
    │   │   ├── Commands/
    │   │   │   ├── CreateTask/
    │   │   │   │   ├── CreateTaskCommand.cs
    │   │   │   │   ├── CreateTaskCommandHandler.cs
    │   │   │   │   └── CreateTaskCommandValidator.cs
    │   │   │   ├── DeleteTask/
    │   │   │   └── ToggleTaskCompletion/
    │   │   └── Queries/
    │   │       └── GetTasks/
    │   ├── DTOs/
    │   └── Common/
    │
    ├── TaskManagementApp.Infrastructure/
    │   ├── Persistence/
    │   │   ├── ApplicationDbContext.cs
    │   │   └── DataSeeder.cs
    │   ├── Repositories/
    │   │   └── TaskRepository.cs
    │   ├── Mapping/
    │   │   └── MappingProfile.cs
    │   └── DependencyInjection.cs
    │
    └── TaskManagementApp.Web/
        ├── Controllers/
        │   └── TasksController.cs
        ├── wwwroot/
        │   ├── index.html (Main UI)
        │   └── css/
        │       └── site.css (Modern styles)
        └── Program.cs
```

---

## 🎨 UI Features

### **Modern Design:**
- Beautiful gradient backgrounds (purple/pink/green)
- Smooth animations and transitions
- Glass-morphism effects
- Responsive layout (mobile, tablet, desktop)
- Card-based task display
- Real-time statistics dashboard

### **User Experience:**
- Instant visual feedback on all actions
- Confirmation dialogs for destructive actions
- Loading indicators
- Empty state messages
- Form validation
- Responsive buttons with hover effects

---

## 🔧 API Endpoints

### **Base URL:** `http://localhost:5000/api/tasks`

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks?filter=0` | Get all tasks (0=All, 1=Pending, 2=Completed) |
| POST | `/api/tasks` | Create a new task |
| PUT | `/api/tasks/{id}/toggle` | Toggle task completion status |
| DELETE | `/api/tasks/{id}` | Delete a task |

### **Example Requests:**

**Get All Tasks:**
```bash
curl http://localhost:5000/api/tasks?filter=0
```

**Create Task:**
```bash
curl -X POST http://localhost:5000/api/tasks \
  -H "Content-Type: application/json" \
  -d '{"title":"New Task","description":"Task description"}'
```

**Toggle Task:**
```bash
curl -X PUT http://localhost:5000/api/tasks/1/toggle
```

**Delete Task:**
```bash
curl -X DELETE http://localhost:5000/api/tasks/1
```

---

## 📊 Sample Data

The application comes pre-seeded with **8 sample tasks:**
- 5 Pending tasks
- 3 Completed tasks

Sample tasks include:
- Complete project documentation
- Review pull requests (✓ Completed)
- Update dependencies (✓ Completed)
- Implement user authentication
- Design database schema (✓ Completed)
- Conduct code review session
- Fix responsive layout issues
- Prepare for deployment

---

## 🧪 Testing the Application

### **Manual Testing Checklist:**

1. **View Tasks:**
   - ✅ Should see 8 pre-seeded tasks
   - ✅ Tasks display with title, description, and creation date
   - ✅ Completed tasks have strikethrough styling

2. **Filter Tasks:**
   - ✅ Click "All Tasks" - shows all 8 tasks
   - ✅ Click "Pending" - shows 5 pending tasks
   - ✅ Click "Completed" - shows 3 completed tasks
   - ✅ Statistics update correctly

3. **Add New Task:**
   - ✅ Enter title and description
   - ✅ Click "+ Add" button
   - ✅ Task appears in the list immediately
   - ✅ Form clears after submission
   - ✅ Statistics update

4. **Toggle Task Status:**
   - ✅ Click checkmark on pending task → becomes completed
   - ✅ Click undo on completed task → becomes pending
   - ✅ UI updates immediately
   - ✅ Statistics update

5. **Delete Task:**
   - ✅ Click trash button
   - ✅ Confirmation dialog appears
   - ✅ Task removed after confirmation
   - ✅ Statistics update

6. **Responsive Design:**
   - ✅ Test on desktop (3 columns)
   - ✅ Test on tablet (2 columns)
   - ✅ Test on mobile (1 column)

---

## 💡 Technical Highlights

### **Design Patterns:**
- **CQRS:** Separate Commands and Queries
- **Mediator:** MediatR for decoupling
- **Repository:** Data access abstraction
- **Dependency Injection:** Throughout all layers
- **Result Pattern:** For error handling

### **Code Quality:**
- **Clean Architecture:** Proper layer separation
- **SOLID Principles:** Applied throughout
- **Async/Await:** All operations are async
- **CancellationToken:** Proper cancellation support
- **Validation:** FluentValidation for input validation
- **Mapping:** AutoMapper for DTO conversions

### **Technology Stack:**
- **.NET 9.0**
- **C# 12**
- **Entity Framework Core 9.0** (InMemory)
- **MediatR 12.2**
- **AutoMapper 12.0**
- **FluentValidation 11.8**
- **Bootstrap 5.3**
- **Vanilla JavaScript** (ES6+)

---

## 🎓 Evaluation Criteria Met

| Criteria | Status | Notes |
|----------|--------|-------|
| Code structure and cleanliness | ✅ | Clean Architecture with clear separation |
| Use of Clean Architecture | ✅ | 4 layers properly implemented |
| Component design | ✅ | Modern HTML/JS with REST API |
| Proper use of Entity Framework | ✅ | InMemory DB with proper configuration |
| Error handling and validation | ✅ | Result pattern + FluentValidation |
| **BONUS:** Unit tests | ⚠️ | Test project structure ready |
| **BONUS:** Responsive UI | ✅ | Modern, gradient-based responsive design |
| **BONUS:** Dependency Injection | ✅ | Used throughout all layers |
| **BONUS:** Async/await | ✅ | All operations with CancellationToken |

---

## 🐛 Troubleshooting

### **Port Already in Use:**
If port 5000 is busy, run on a different port:
```bash
dotnet run --urls="http://localhost:6000"
```

### **Build Errors:**
Clean and rebuild:
```bash
dotnet clean
dotnet build
```

### **.NET SDK Not Found:**
Install .NET 9.0 SDK from: https://dotnet.microsoft.com/download

---

## 📝 Notes

- **Database:** Uses EF Core InMemory - data resets on restart
- **No Authentication:** Simplified for technical test
- **CORS:** Enabled for API testing
- **Static Files:** Served from wwwroot folder
- **Default Page:** index.html serves as main UI

---

## 🎉 Summary

This is a **complete, working Task Management Application** that demonstrates:
- ✅ Clean Architecture principles
- ✅ CQRS pattern implementation
- ✅ Modern responsive UI/UX
- ✅ All required CRUD operations
- ✅ Professional code organization
- ✅ Best practices throughout

**Ready for evaluation and demonstration!**

---

**Built with ❤️ using .NET 9.0 and Clean Architecture**
