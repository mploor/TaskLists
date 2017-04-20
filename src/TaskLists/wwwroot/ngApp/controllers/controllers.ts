namespace TaskLists.Controllers {

    class myTaskList {
        id: number
    }

    class myTask {
        id: number;
        name: string;
        description: string;
        status: string;
        taskList: myTaskList;
    }

    export class HomeController {
        public tasklists;
        public taskName;
        public taskDescription;
        public taskStatus;
        public taskId;
        public taskListId;
        public taskListName;
        public divheight = "600px";

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get("/api/tasklists").then((response) => {
                this.tasklists = response.data;
                for (var j = 0; j < this.tasklists.length; j++) {
                    // Determine height of each list based on number of tasks in it
                    var pixheight = this.tasklists[j].tasks.length * 90 + 10;
                    if (pixheight > 650) {
                        pixheight = 650;
                    }
                    this.tasklists[j].divheight = pixheight + "px";
                    for (var i = 0; i < this.tasklists[j].tasks.length; i++) {
                        // Set status color based on status for each task
                        if (this.tasklists[j].tasks[i].status == "Pending") {
                            this.tasklists[j].tasks[i].statuscolor = "red";
                        } else if (this.tasklists[j].tasks[i].status == "In Progress") {
                            this.tasklists[j].tasks[i].statuscolor = "yellow";
                        } else if (this.tasklists[j].tasks[i].status == "Completed") {
                            this.tasklists[j].tasks[i].statuscolor = "green";
                        }
                    }
                }
            });
        }

        // Load info for selected task
        public showInfo(id: number, name: string, description: string, status: string) {
            this.taskName = name;
            this.taskDescription = description;
            this.taskStatus = status;
            this.taskId = id;
        }

        // Create new task
        public newTask(listId: number) {
            this.taskName = "";
            this.taskDescription = "";
            this.taskStatus = "Pending";
            this.taskId = 0;
            this.taskListId = listId;
        }

        // Save new task or update existing task
        public saveUpdate() {
            var currTask = new myTask;
            currTask.id = this.taskId;
            currTask.name = this.taskName;
            currTask.description = this.taskDescription;
            currTask.status = this.taskStatus;
            currTask.taskList = new myTaskList;
            currTask.taskList.id = this.taskListId;
            this.$http.post("/api/tasks", currTask).then((response) => {
                this.$state.reload();
            });
        }

        // Create new task list
        public addList() {
            this.$http.post("/api/taskLists", JSON.stringify(this.taskListName)).then((response) => {
                this.$state.reload();
            });
        }

        // Delete a task
        public deleteTask() {
            this.$http.delete("/api/tasks/" + this.taskId).then((response) => {
                this.$state.reload();
            });
        }
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
