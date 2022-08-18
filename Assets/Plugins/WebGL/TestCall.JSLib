mergeInto(LibraryManager.library, {
  CallReact: function (gameOver) {
    try {
      window.dispatchReactUnityEvent("CallReact", gameOver);
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
});