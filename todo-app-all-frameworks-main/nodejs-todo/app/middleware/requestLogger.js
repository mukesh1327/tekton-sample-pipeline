// requestLogger.js

const fs = require('fs');
const path = require('path');

// Define a log file path where request logs will be written
const logFilePath = path.join(__dirname, 'requestLogs.txt');

// Create a writable stream to the log file
const logStream = fs.createWriteStream(logFilePath, { flags: 'a' });

// Custom request logging middleware
const requestLogger = (req, res, next) => {
  const logEntry = `[${new Date().toISOString()}] ${req.method} ${req.url}`;

  // Write the log entry to the log file
  logStream.write(logEntry + '\n', 'utf8', (err) => {
    if (err) {
      console.error('Error writing to log file:', err);
    }
  });

  // Log the request details to the console
  console.log(logEntry);

  // Continue to the next middleware or route handler
  next();
};

module.exports = requestLogger;