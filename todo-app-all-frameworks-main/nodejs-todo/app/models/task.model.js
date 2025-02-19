module.exports = (sequelize, Sequelize) => {
  const Task = sequelize.define("task", {
    name: {
      type: Sequelize.STRING,
      unique: true,
      allowNull: false,
    },
    description: {
      type: Sequelize.STRING
    },
    status: {
      type: Sequelize.ENUM('PENDING', 'IN_PROGRESS', 'DONE', 'DROPPED', 'KILLED'),
      allowNull: false,
      defaultValue: 'PENDING'
    },
    dueDate: {
      type: Sequelize.DATEONLY
    }

  });

  return Task;
};
