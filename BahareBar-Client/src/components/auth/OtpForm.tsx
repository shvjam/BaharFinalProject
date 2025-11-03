// File: BahareBar-Client/src/components/auth/OtpForm.tsx
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { InputOTP, InputOTPGroup, InputOTPSlot } from "@/components/ui/input-otp";
import { Label } from "@/components/ui/label";
import api from "@/services/api";
import { authService } from "@/services/auth";

export function OtpForm({ phoneNumber }: { phoneNumber: string }) {
    const [otp, setOtp] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleVerifyOtp = async (e: React.FormEvent) => {
        e.preventDefault();
        setError("");
        try {
            const response = await api.post("/auth/verify-otp", { phoneNumber, code: otp });
            authService.setToken(response.data.token);
            navigate("/"); // Redirect to home page on successful login
        } catch (err) {
            setError("کد وارد شده صحیح نیست یا منقضی شده است.");
            console.error(err);
        }
    };

    return (
        <form onSubmit={handleVerifyOtp}>
            <div className="grid gap-4">
                <div className="grid gap-2 text-center">
                    <Label htmlFor="otp">کد تایید را وارد کنید</Label>
                    <p className="text-sm text-muted-foreground">
                        کد ۶ رقمی ارسال شده به شماره {phoneNumber} را وارد کنید.
                    </p>
                </div>
                <InputOTP maxLength={6} id="otp" value={otp} onChange={(value) => setOtp(value)}>
                    <InputOTPGroup dir="ltr">
                        <InputOTPSlot index={0} />
                        <InputOTPSlot index={1} />
                        <InputOTPSlot index={2} />
                        <InputOTPSlot index={3} />
                        <InputOTPSlot index={4} />
                        <InputOTPSlot index={5} />
                    </InputOTPGroup>
                </InputOTP>
                <Button type="submit" className="w-full">
                    تایید و ادامه
                </Button>
                {error && <p className="text-sm text-red-500 text-center">{error}</p>}
            </div>
        </form>
    );
}
