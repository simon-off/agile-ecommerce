import { describe, expect, test } from "vitest";
import getCookieByName from "../../src/helpers/getCookieByName";

describe("getCookieByName function", () => {
  test("getCookieByName", () => {
    // Set up a mock cookie
    document.cookie = "testCookie=testValue";

    // Test that the function correctly retrieves the cookie value
    const cookieValue = getCookieByName("testCookie");
    expect(cookieValue).toBe("testValue");

    // Test that the function returns null for a non-existent cookie
    const nonExistentCookieValue = getCookieByName("nonExistentCookie");
    expect(nonExistentCookieValue).toBe(null);
  });
});
