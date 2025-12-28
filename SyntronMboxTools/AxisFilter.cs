public class AxisFilter
{
    private bool _initialized = false;
    private float _center;

    private float _deadband = 0.1f;
    // Tune these:
    public int DeadZone { get; set; } = 2000;          // counts around center = no movement
    public int JitterThreshold { get; set; } = 500;    // counts where we "learn" new center
    public float CenterSmoothFactor { get; set; } = 0.01f; // 1% towards new center

    // Output: -1 .. +1
    public float Value { get; private set; }

    public void Update(int raw)
    {
        if (!_initialized)
        {
            _center = raw;
            _initialized = true;
        }

        // 1) Adjust center slowly while near it
        float diff = raw - _center;

        if (Math.Abs(diff) < JitterThreshold)
        {
            _center += diff * CenterSmoothFactor;
        }

        // 2) Recompute diff using (possibly) updated center
        diff = raw - _center;

        // 3) Apply dead zone
        if (Math.Abs(diff) <= DeadZone)
        {
            Value = 0f;
            return;
        }

        // Remove dead zone so output starts from 0 at its edge
        if (diff > 0)
            diff -= DeadZone;
        else
            diff += DeadZone;

        // 4) Compute normalized range separately for each side
        float maxPositive = 65535f - _center - DeadZone;
        float maxNegative = _center - DeadZone;    // distance from 0 to center minus dead zone

        float norm;

        if (diff > 0)
        {
            // right side
            if (maxPositive <= 0) maxPositive = 1; // avoid division by 0
            norm = diff / maxPositive;            // 0 .. +1
        }
        else
        {
            // left side
            if (maxNegative <= 0) maxNegative = 1;
            norm = diff / maxNegative;            // 0 .. -1 (diff is negative)
        }

        // Clamp
        if (norm > 1f) norm = 1f;
        if (norm < -1f) norm = -1f;


        if (Math.Abs(norm) < _deadband) Value = 0;
        else
           Value = norm;
    }

    public float Center => _center; // handy for debugging
}
