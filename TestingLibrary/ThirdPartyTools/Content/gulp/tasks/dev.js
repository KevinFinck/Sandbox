var gulp        = require('gulp');
var config      = require('../config-docs');
var livereload  = require('gulp-livereload');
var lr          = require('tiny-lr')();
var path        = require('path');

//puts this on global to share with the reload file
global.lr = lr;

//sets to docs paths

gulp.task('dev', ['fileinclude', 'sass-docs', 'reload-docs', 'connect'], function () {
  lr.listen(config.LIVERELOAD_PORT);
  gulp.watch([path.join(config.paths.sass, '**/*.scss'), './css/source/**/*.scss'], ['sass-docs']);
  gulp.watch(path.join(config.paths.templates, '**/*.html'), ['fileinclude']);
});
