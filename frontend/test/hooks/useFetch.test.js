import { describe, expect, it } from "vitest";
import useFetch from "../../src/hooks/useFetch";
import { renderHook, waitFor } from "@testing-library/react";

describe("useFetch", () => {
  it("Should return the loading state and any errors or the data", async () => {
    const { result } = renderHook(() => useFetch("https://httpbin.org/get"));

    expect(result.current.isLoading).toBe(true);

    await waitFor(() => {
      expect(result.current.isLoading).toBe(false);
      expect(result.current.error).toBeNull();
      expect(result.current.data).instanceOf(Object);
    });
  });
});
