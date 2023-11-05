import { useEffect } from "react";

/**
 * Custom hook that triggers when the window is resized
 * @param callback Function to run every time the window "resize" event is triggered
 * @param callbackOnLoad Whether to also trigger the callback function when component is mounted
 */
export default function useWindowResize(callback, callbackOnLoad) {
  useEffect(() => {
    if (callbackOnLoad) callback();
    window.addEventListener("resize", callback);
    return () => window.removeEventListener("resize", callback);
  }, [callback, callbackOnLoad]);
}
