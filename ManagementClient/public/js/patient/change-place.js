$("#change-place-form").submit(function (e) {
  if (checkPlace()) return true;
  return false;
});
