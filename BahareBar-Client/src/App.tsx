// File: BahareBar-Client/src/App.tsx
import { Button } from "@/components/ui/button";

function App() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-background text-foreground">
      <h1 className="text-3xl font-bold mb-4">پروژه باربری بهار</h1>
      <p className="mb-6">زیرساخت پروژه با موفقیت ایجاد شد.</p>
      <Button>این یک دکمه از shadcn/ui است</Button>
    </div>
  );
}

export default App;
