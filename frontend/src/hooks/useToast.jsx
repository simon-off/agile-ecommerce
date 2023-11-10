import { createContext, useContext, useEffect, useRef, useState } from "react";

const ToastContext = createContext(null);

export function ToastContextProvider({ children }) {
  const toastsRef = useRef([]);
  const [toasts, setToasts] = useState([]);

  useEffect(() => {
    toastsRef.current = toasts;
  }, [toasts]);

  const add = (message, color = "var(--color-success)") => {
    setToasts([...toasts, { message, color, timestamp: Date.now() }]);
    setTimeout(() => {
      setToasts(toastsRef.current.splice(1, toastsRef.current.length));
    }, 2500);
  };

  return (
    <ToastContext.Provider value={{ add }}>
      <div className="toasts">
        {toasts.map((toast) => (
          <div
            key={toast.timestamp}
            className="toast"
            style={{ backgroundColor: toast.color, borderColor: toast.color }}
          >
            {toast.message}
          </div>
        ))}
      </div>
      {children}
    </ToastContext.Provider>
  );
}

export const useToast = () => useContext(ToastContext);
