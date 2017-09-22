var gulp      = require('gulp');
var connect   = require('gulp-connect');
var config    = require('../config');
var path      = require('path');

//  Connect: sever task
//===========================================
gulp.task('connect', connect.server({
  port: config.port,
  root: [path.join(__dirname, '..', '..')],
  livereload: false
}));
