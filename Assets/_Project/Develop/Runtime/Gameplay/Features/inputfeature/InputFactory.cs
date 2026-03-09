using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.inputfeature
{
    public class InputFactory
    {

        public DesktopInput CreateDesktopInput()
            => new DesktopInput();

        public MouseRotationInput CreateMouseRotationInput()
            => new MouseRotationInput();
        
        public AttackInput CreateAttackInput()
            => new AttackInput();
    }
}
