
### 1️⃣ Create a Product Requirement Document (PRD)

```text
Use #file:create-prd.md
Here's the feature I want to build: [Describe feature in detail]
Reference these files to help you: [Optional: #file:Program.cs #file:ServiceClass.cs]
```

### 2️⃣ Generate Task List from the PRD

```text
Now take #file:prd-FEATURE.md and create tasks using #file:generate-tasks.md
```

### 3️⃣ Examine Task List

You'll now have a well-structured task list, often with tasks and sub-tasks, ready for the AI to start working on. This provides a clear roadmap for implementation.

### 4️⃣ Instruct the AI to Work Through Tasks (and Mark Completion)

```text
Please start on task 1 and use #file:process-task-list.md
```
*(Important: You only need to reference ` #file:process-task-list.md` for the *first* task. The instructions within it guide the AI for subsequent tasks.)*

The AI will attempt the task and then prompt to review.

### 5️⃣ Review, Approve, and Progress ✅

As the AI completes each task, you review the changes.

* If the changes are good, simply reply with "yes" (or a similar affirmative) to instruct the AI to mark the task complete and move to the next one.
* If changes are needed, provide feedback to the AI to correct the current task before moving on.


##### Reference: https://github.com/snarktank/ai-dev-tasks/