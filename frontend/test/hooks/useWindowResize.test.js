import { expect, test } from "vitest";
import useWindowResize from "../../src/hooks/useWindowResize";
import { renderHook } from "@testing-library/react";

test("useWindowResize", () => {
  let isMobile = false;
  let isDesktop = false;
  const callback = () => {
    if (window.innerWidth <= 768) {
      isMobile = true;
    } else {
      isDesktop = true;
    }
  };

  // Render the hook in a test component
  renderHook(() => useWindowResize(callback, true));

  // Check that the callback was called on load
  expect(isMobile || isDesktop).toBe(true);

  // Simulate a window resize event
  window.innerWidth = 800;
  window.dispatchEvent(new Event("resize"));

  // Check that the callback was called when the window was resized
  expect(isDesktop).toBe(true);
});