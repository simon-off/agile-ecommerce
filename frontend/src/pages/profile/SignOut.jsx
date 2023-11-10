import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useToast } from "../../hooks/useToast";

function SignOut() {
  const navigate = useNavigate();
  const toast = useToast();

  useEffect(() => {
    // delete auth token by setting date in the past
    document.cookie = "Authorization=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
    localStorage.clear();
    window.location.reload();

    navigate("/signin");
  }, [navigate, toast]);

  return null;
}

export default SignOut;
