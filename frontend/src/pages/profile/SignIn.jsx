import { Check, EyeOff, Facebook, Twitter, Eye } from "lucide-react";
import { Link, useNavigate } from "react-router-dom";
import ThemedInput from "../../components/ThemedInput";
import { useState, useEffect } from "react";
import { apiDomain } from "../../helpers/apiDomain";
import getCookieByName from "../../helpers/getCookieByName";
import { useToast } from "../../hooks/useToast";

export default function SignIn() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [rememberMe, setRememberMe] = useState(false);
  const [passwordIsHidden, setPasswordIsHidden] = useState(true);
  const navigate = useNavigate();
  const authToken = getCookieByName("Authorization");
  const toast = useToast();

  useEffect(() => {
    if (authToken) {
      // If you already are logged in you should not be able to access this page
      navigate("/profile");
    }
  }, [authToken, navigate]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const signInData = {
      email: email,
      password: password,
    };
    try {
      const response = await fetch(`${apiDomain.https}/api/account/signin`, {
        method: "POST",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(signInData),
      });

      if (!response.ok) {
        if (response.status >= 400 && response.status <= 499) {
          throw new Error("Invalid credentials, please try again.");
        }

        const errorMessage = await response.text();
        throw new Error(`Error: ${response.status}. ${errorMessage}`);
      }

      const data = await response.json();

      if (!rememberMe) {
        document.cookie = `Authorization=${data.token.result}; path=/; secure; SameSite=Lax`;
      } else {
        const token = data.token.result;
        const decodedToken = JSON.parse(atob(token.split(".")[1]));
        const expirationDate = new Date(decodedToken.exp * 1000);

        document.cookie = `Authorization=${
          data.token.result
        }; path=/; secure; SameSite=Lax; expires=${expirationDate.toUTCString()}`;
      }

      toast.add("Successfully signed in!");
      navigate("/");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <>
      <div className="signin-container">
        <h1>Welcome Back!</h1>
        <h3>Sign in to continue</h3>
        <form onSubmit={handleSubmit}>
          <div className="signin-detail">
            <ThemedInput
              label="Email"
              type="email"
              regex={"^[\\w-\\.]+@([\\w-]+.)+[\\w-]{2,4}$"}
              error={"Must be a valid email address"}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              maxLength={320}
              minLength={1}
              required
            >
              <Check />
            </ThemedInput>
            <ThemedInput
              label="Password"
              type={passwordIsHidden ? "password" : "text"}
              required
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            >
              <button type="button" onClick={() => setPasswordIsHidden(!passwordIsHidden)}>
                {passwordIsHidden ? <EyeOff /> : <Eye />}
              </button>
            </ThemedInput>
          </div>
          <div className="config-content">
            <div>
              <label>
                <input
                  className="checkbox"
                  type="checkbox"
                  name="rememberme"
                  value={rememberMe}
                  onChange={(e) => setRememberMe(e.target.checked)}
                />
                Remember me
              </label>
            </div>
            <Link className="redirect-link" to="/forgot-password">
              Forgot password?
            </Link>
          </div>
          <button type="submit" className="button button-black">
            SIGN IN
          </button>
          <Link className="redirect-link" to="/signup">
            Don’t have an account? Sign up.
          </Link>
        </form>

        <div className="signin-options">
          <Link to={"/facebook-auth"}>
            <div className="icon facebook">
              <Facebook />
            </div>
          </Link>
          <Link to={"/twitter-auth"}>
            <div className="icon twitter">
              {" "}
              <Twitter />
            </div>
          </Link>
          <Link to={"google-auth"}>
            <div className="image-icon">
              <img src="\images\google plus.png" alt="google-icon" />
            </div>
          </Link>
        </div>
      </div>
    </>
  );
}
