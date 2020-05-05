var gulp        = require('gulp');
var livereload  = require('gulp-livereload');
var path        = require('path');

gulp.task('reload-docs', function () {
  var server = livereload(lr);
  gulp.watch(['**/*.css', '**/*.html'])
    .on('change', function (file) {
      server.changed(file.path);
    });
});
