import { useEffect, useMemo, useState } from "react";
import getCookieByName from "../helpers/getCookieByName";

export default function useFetch(url) {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const authToken = getCookieByName("Authorization");

  const headers = useMemo(() => new Headers(), []);
  headers.append("Content-Type", "application/json");

  if (authToken) {
    headers.append("Authorization", `Bearer ${authToken}`);
  }

  useEffect(() => {
    const getData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch(url, {
          method: "GET",
          headers: headers,
        });

        if (!response.ok) {
          throw Error(`${response.status}: ${await response.text()}`);
        }
        const data = await response.json();
        setData(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setIsLoading(false);
      }
    };
    getData();
  }, [url, headers]);

  return { data, error, isLoading };
}
