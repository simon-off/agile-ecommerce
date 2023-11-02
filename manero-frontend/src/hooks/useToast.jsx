import { createContext, useContext, useEffect, useRef, useState } from "react";

const ToastContext = createContext(null);

export function ToastContextProvider({ children }) {
  const toastsRef = useRef([]);
  const [toasts, setToasts] = useState([]);

  useEffect(() => {
    toastsRef.current = toasts;
  }, [toasts]);

  const add = (message) => {
    setToasts([...toasts, { message, timestamp: Date.now() }]);
    setTimeout(() => {
      setToasts(toastsRef.current.splice(1, toastsRef.current.length));
    }, 1500);
  };

  return (
    <ToastContext.Provider value={{ add }}>
      <div className="toasts">
        {toasts.map((toast) => (
          <div key={toast.timestamp} className="toast">
            {toast.message}
          </div>
        ))}
      </div>
      {children}
    </ToastContext.Provider>
  );
}

export const useToast = () => useContext(ToastContext);
