$("#change-state-form").submit(function () {
  if (!checkState()) {
    return false;
  } else {
    return true;
  }
});
