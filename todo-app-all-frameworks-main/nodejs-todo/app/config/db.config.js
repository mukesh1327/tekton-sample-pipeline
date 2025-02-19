module.exports = {
  HOST: "localhost",
  USER: "nodejs-admin",
  PASSWORD: "nodejs-admin",
  DB: "nodejs-crud-todo",
  PORT: "5435",
  dialect: "postgres",
  pool: {
    max: 5,
    min: 0,
    acquire: 30000,
    idle: 10000
  }
};
