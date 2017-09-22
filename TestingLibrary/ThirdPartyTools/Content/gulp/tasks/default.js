var gulp        = require('gulp');
var config      = require('../config');
var livereload  = require('gulp-livereload');
var lr          = require('tiny-lr')();
var path        = require('path');

//puts this on global to share with the reload file
global.lr = lr;

gulp.task('default', ['sass', 'reload', 'connect'], function () {
  lr.listen(config.LIVERELOAD_PORT);
  gulp.watch(path.join(config.paths.sass, '**/*.scss'), ['sass']);
});