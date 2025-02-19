module.exports = app => {
  const tasks = require("../controllers/task.controller.js");

  var router = require("express").Router();

  // Create a new Task
  router.post("/create", tasks.create);

  // Retrieve all Tasks
  router.get("/read", tasks.findAll);

  // Retrieve a single Task with id
  router.get("/get/:id", tasks.findOne);

  // Update a Task with id
  router.put("/update/:id", tasks.update);

  // Delete a Task with id
  router.delete("/delete/:id", tasks.delete);

  app.use("/api/tasks", router);
};
