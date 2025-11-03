// File: BahareBar-Client/src/pages/LoginPage.tsx
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { OtpForm } from "@/components/auth/OtpForm";
import api from "@/services/api";

export function LoginPage() {
    const [phoneNumber, setPhoneNumber] = useState("");
    const [otpSent, setOtpSent] = useState(false);
    const [error, setError] = useState("");

    const handleSendOtp = async (e: React.FormEvent) => {
        e.preventDefault();
        setError("");
        try {
            await api.post("/auth/send-otp", { phoneNumber });
            setOtpSent(true);
        } catch (err) {
            setError("خطا در ارسال کد. لطفاً دوباره تلاش کنید.");
            console.error(err);
        }
    };

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-gray-900">
            <Card className="w-full max-w-sm">
                <CardHeader>
                    <CardTitle className="text-2xl">ورود | ثبت‌نام</CardTitle>
                    <CardDescription>
                        {otpSent
                            ? "کد تایید ارسال شده را وارد کنید."
                            : "برای ورود یا ثبت‌نام، شماره موبایل خود را وارد کنید."}
                    </CardDescription>
                </CardHeader>
                <CardContent>
                    {!otpSent ? (
                        <form onSubmit={handleSendOtp}>
                            <div className="grid gap-4">
                                <div className="grid gap-2">
                                    <Label htmlFor="phone">شماره موبایل</Label>
                                    <Input
                                        id="phone"
                                        type="tel"
                                        placeholder="0912..."
                                        required
                                        dir="ltr"
                                        value={phoneNumber}
                                        onChange={(e) => setPhoneNumber(e.target.value)}
                                    />
                                </div>
                                <Button type="submit" className="w-full">
                                    ارسال کد تایید
                                </Button>
                                {error && <p className="text-sm text-red-500 text-center">{error}</p>}
                            </div>
                        </form>
                    ) : (
                        <OtpForm phoneNumber={phoneNumber} />
                    )}
                </CardContent>
            </Card>
        </div>
    );
}
