var gulp = require('gulp');
var args = require('yargs').argv;
var ftpConfig = require('./ftp.config')();
//var coffee = require('gulp-coffee');
//var concat = require('gulp-concat');
//var uglify = require('gulp-uglify');
//var imagemin = require('gulp-imagemin');
//var sourcemaps = require('gulp-sourcemaps');
var del = require('del');
var $ = require('gulp-load-plugins')({lazy: true});
var paths = {
    scripts: ['app/**/*.js'],
};

// Not all tasks need to use streams
// A gulpfile is just another node program and you can use all packages available on npm
gulp.task('clean', function(cb) {
    // You can use multiple globbing patterns as you would with `gulp.src`
    del(['build']).then(function() {
      cb();
  });
});

gulp.task('scripts', ['clean'], function() {
    // Minify and copy all JavaScript (except vendor scripts)
    // with sourcemaps all the way down
    return gulp.src(paths.scripts)
      .pipe($.sourcemaps.init())
      .pipe($.uglify())
      .pipe($.concat('all.min.js'))
      .pipe($.sourcemaps.write())
      .pipe(gulp.dest('build/app'));
});

gulp.task('deploy',function() {

    return gulp.src('xyz.txt')
      .pipe($.ftp({
          host: ftpConfig.host,
          user: ftpConfig.user,
          pass: ftpConfig.pass,
          remotePath:'/folder'
      }))
    // you need to have some kind of stream after gulp-ftp to make sure it's flushed
    // this can be a gulp plugin, gulp.dest, or any kind of stream
    // here we use a passthrough stream
    .pipe($.util.noop());
});
// Copy all static images
gulp.task('images', ['clean'], function() {
    return gulp.src(paths.images)
    // Pass in options to the task
    .pipe($.imagemin({optimizationLevel: 5}))
    .pipe(gulp.dest('build/img'));
});

// Rerun the task when a file changes
gulp.task('watch', function() {
    gulp.watch(paths.scripts, ['scripts']);
    gulp.watch(paths.images, ['images']);
});

// The default task (called when you run `gulp` from cli)
gulp.task('default', ['watch', 'scripts']);
